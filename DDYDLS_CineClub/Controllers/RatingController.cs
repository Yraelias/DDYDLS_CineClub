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
    public class RatingController : ControllerBase
    {
        private IRatingService _RatingService;
        public RatingController(IRatingService RatingService)
        {
            _RatingService = RatingService;
        }
        // GET: api/<Rating>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_RatingService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Rating>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                
                return Ok(_RatingService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Rating>/5
        [HttpGet("movie/{id}")]
        public IActionResult GetRatingForMovie(int id)
        {
            try
            {

                return Ok(_RatingService.GetRatingbyMovie(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Rating>/5
        [HttpGet("user/{id}")]
        public IActionResult GetRatingsbyUser(int id)
        {
            try
            {

                return Ok(_RatingService.RatingsbyUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Rating>/5
        [HttpGet("user/year/{id}/{year}")]
        public IActionResult GetRatingsbyUserbyYear(int id, int year)
        {
            try
            {

                return Ok(_RatingService.RatingsbyUserbyYear(id,year));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<Rating>/5
        [HttpGet("user/month/{id}/{month}/{year}")]
        public IActionResult GetRatingsbyUserbyMonthbyYear(int id,int Month, int Year)
        {
            try
            {

                return Ok(_RatingService.RatingsbyUserbyMonth(id,Month,Year));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("cineclub/{id}")]
        public IActionResult GetRatingsForCineclub(int id)
        {
            try
            {
                return Ok(_RatingService.RatingsForCineclub(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<Rating>
        [HttpPost]
        public IActionResult Post([FromBody] api.Rating Rating)
        {
            try
            {
                _RatingService.AddOrUpdate(Rating.toLocal());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<User>/5
        [HttpPut]
        public IActionResult Put([FromBody] api.Rating Rating)
        {
            try
            {
                
                _RatingService.AddOrUpdate(Rating.toLocal());
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
                return Ok(_RatingService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
