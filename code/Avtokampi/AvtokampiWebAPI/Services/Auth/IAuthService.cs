using System;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models.AuthAggregate;

namespace AvtokampiWebAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<Tuple<bool, string>> IsAuthenticated(TokenDto request);

        Task<bool> IsValidUser(string username, string password);

        Task<bool> IsRegister(RegisterDto user);
    }
}