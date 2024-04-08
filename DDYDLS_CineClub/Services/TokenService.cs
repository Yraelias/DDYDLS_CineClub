using DDYDLS_CineClubApi.Models;
using DDYDLS_CineClubApi.Tools;
using DDYDLS_CineClubLocalModel.Services.Interfaces;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace DDYDLS_CineClubApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings appSettings;
        private IUserService _userService;
        public TokenService(IOptions<AppSettings> options, IUserService userService)
        {
            appSettings = options.Value;
            _userService = userService;
        }
        public UserWithToken Authenticate(string email, string password)
        {
            User user = new User { Email = email, Password = password };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            if(_userService.CheckUser(user.toLocal()) == true)
            {
                user = _userService.GetByEmail(email).toApi();
            }
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID_User.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdministrator ? "Admin" : "User")
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserWithToken
            {
                ID_User = user.ID_User,
                Email = user.Email,
                Registration_Date = user.Registration_Date,
                Username = user.Username,
                Login = user.Login,
                IsActive = user.IsActive,
                IsAdministrator = user.IsAdministrator,
                Token = tokenHandler.WriteToken(token),
                IsModerator = user.IsModerator
            };
        }
    }
}
