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
    public class MovieController : ControllerBase
    {
        private IMovieService _MovieService;
        public MovieController(IMovieService MovieService)
        {
            _MovieService = MovieService;
        }
        // GET: api/<Movie>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_MovieService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Movie>/UserId/5
        [HttpGet("{UserId}/{id}")]
        public IActionResult Get(int userId, int id)
        {
           /* try
            {
                */
                return  Ok(_MovieService.GetOne(userId, id));
            /*}
            catch (Exception e)
            { */
                //return BadRequest(e.Message);
            //}
        }

        // POST api/<Movie>
        [HttpPost]
        public IActionResult Post([FromForm] api.Movie Movie)
        //public IActionResult Post(api.UserCreate user)
        {
            Movie newUser = new Movie();
            try
            {
                _MovieService.AddMovie(Movie.toLocal());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
}

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] api.Movie Movie)
        {
            try
            {
                
                _MovieService.Update(Movie.toLocal());
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
                return Ok(_MovieService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
