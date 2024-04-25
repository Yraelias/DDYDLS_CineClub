using DDYDLS_CineClubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDYDLS_CineClubApi.Services
{
    public interface ITokenService
    {
        UserWithToken Authenticate(string email, string password);
        string HashPassword(string password);
    }
}
