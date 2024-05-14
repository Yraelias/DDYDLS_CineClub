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
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDYDLS_CineClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineclubController : ControllerBase
    {
        private ICineclubService _CineclubService;
        public CineclubController(ICineclubService CineclubService)
        {
            _CineclubService = CineclubService ;
        }
        // GET: api/<Movie>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_CineclubService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET api/<Movie>/UserId/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // try
            // {
                 
            return Ok(_CineclubService.GetOne(id));
           /// }
        //catch (Exception e)
          //  { 
          //  return BadRequest(e.Message);
          //  }
        }
        // POST api/<Movie>
        [HttpPost]
        public IActionResult Post([FromBody] api.Cineclub Cineclub)
        {
            Cineclub cineclub = new Cineclub();
            try
            {
                _CineclubService.Add(Cineclub.toLocal("Add"));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] api.Cineclub cineclub)
        {
            try
            {
                
                _CineclubService.Update(cineclub.toLocal());
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
                return Ok(_CineclubService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
