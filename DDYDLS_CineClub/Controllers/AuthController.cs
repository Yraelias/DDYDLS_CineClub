using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDYDLS_CineClubApi.Services;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        
        
    }
}
