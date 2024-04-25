using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DDYDLS_CineClubApi.Tools;
#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using api = DDYDLS_CineClubApi.Models;
using DDYDLS_CineClubApi.Services;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDYDLS_CineClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        // GET: api/<User>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                
                return Ok(_userService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<User>/Desactive/5
        [HttpGet("Desactive/{id}")]
        public IActionResult DesactiveUser(int id)
        {
            try
            {

                return Ok(_userService.Desactive(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<User>
        [HttpPost]
        public IActionResult Post([FromForm] api.UserCreate user)
        //public IActionResult Post(api.UserCreate user)
        {
            User newUser = new User();
            try
            {
                _userService.RegistrationUser(user.toModelUser());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<User>/changePassword
        [HttpPost("changePassword")]
        public IActionResult changePassword([FromBody] api.User user)
        {
            string pass = user.Password;
            string passHash = user.Password;
            //try
            //{ 
                passHash = _tokenService.HashPassword(pass);
                return Ok(_userService.changePassword(user.ID_User,passHash));
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
        }

        // POST api/<User>/changeUsername
        [HttpPost("changeUsername")]
        public IActionResult changeUsername(int id, string password)
        {
            try
            {

                return Ok(_userService.changeUsername(id, password) );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] api.User user)
        {
            try
            {
                
                _userService.Update(user.toLocal());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_userService.Desactive(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
