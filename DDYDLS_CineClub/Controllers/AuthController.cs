using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDYDLS_CineClubApi.Models;
using DDYDLS_CineClubApi.Services;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using YraesportApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDYDLS_CineClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public AuthController(ITokenService tokenService,IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
        public IActionResult Auth([FromBody] LoginInfo model)
        {
            UserWithToken user = _tokenService.Authenticate(model.Email, model.Password);

            if (user.ID_User == 0)
            {
                return BadRequest(new { message = "Utilisateur inexistant !" });
            }
            else
            {
            }
            return Ok(user);
        }

    }
}
