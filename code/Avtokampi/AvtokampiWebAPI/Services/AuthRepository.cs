using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Models.AuthAggregate;
using AvtokampiWebAPI.Models.UserAggregate;
using AvtokampiWebAPI.Services.Interfaces;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TokenManagementDto _tokenManagementDto;
        private readonly IUporabnikiRepository _uporabnikiService;
        private readonly avtokampiContext _db;

        public AuthRepository(IOptions<TokenManagementDto> tokenManagement, IUporabnikiRepository uporabnikiService,
            avtokampiContext db)
        {
            _tokenManagementDto = tokenManagement.Value;
            _uporabnikiService = uporabnikiService;
            _db = db;
        }

        public async Task<Tuple<bool, string>> IsAuthenticated(TokenDto request)
        {
            string token = string.Empty;

            if (!await IsValidUser(request.Username, request.Password)) return new Tuple<bool, string>(false, token);

            var user = await _db.Uporabniki.Where(o => o.Email == request.Username).SingleOrDefaultAsync();
            if (user == null) return new Tuple<bool, string>(false, token);

            var get_permissions = await _db.Pravice.Where(o => o.PravicaId == user.Pravice).Select(o => o.Naziv)
                .FirstOrDefaultAsync() ?? "";
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, get_permissions.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagementDto.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagementDto.Issuer,
                _tokenManagementDto.Audience,
                claim,
                expires: DateTime.Now.AddDays(_tokenManagementDto.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new Tuple<bool, string>(true, token);
        }

        public async Task<bool> IsRegister(RegisterDto user)
        {
            if (await _uporabnikiService.UporabnikExists(user.Email)) return false;

            if (user != null && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Geslo))
            {
                await _db.Uporabniki.AddAsync(new Uporabniki()
                {
                    Ime = user.Ime,
                    Priimek = user.Priimek,
                    Telefon = user.Telefon ?? null,
                    Email = user.Email,
                    Geslo = Crypto.HashPassword(user.Geslo),
                    Pravice = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> IsValidUser(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var user = await _db.Uporabniki.Where(o => o.Email == username).SingleOrDefaultAsync();

                if (user != null && Crypto.VerifyHashedPassword(user.Geslo, password))
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}