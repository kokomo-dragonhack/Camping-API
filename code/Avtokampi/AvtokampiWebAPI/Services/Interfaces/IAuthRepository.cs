using AvtokampiWebAPI.Models.AuthAggregate;
using System;
using System.Threading.Tasks;

namespace AvtokampiWebAPI.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<Tuple<bool, string>> IsAuthenticated(TokenDto request);

        Task<bool> IsValidUser(string username, string password);

        Task<bool> IsRegister(RegisterDto user);
    }
}