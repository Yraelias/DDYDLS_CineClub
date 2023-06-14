using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DDYDLS_CineClubApi.Tools;
using api = DDYDLS_CineClubApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDYDLS_CineClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
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

        // POST api/<User>
        [HttpPost]
        public IActionResult Post([FromBody] api.UserCreate user)
        {
            User newUser = new User();
            try
            {
                _userService.Insert(user.toModelUser());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
}

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] api.User user)
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
