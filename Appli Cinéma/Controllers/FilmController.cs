using Appli_Cinéma.Modele;
using Appli_Cinéma.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("films")]
  
        public class FilmController : Controller
        {
            private readonly IFilmRepository _filmRepository;

            public FilmController(IFilmRepository filmRepository)
            {
                _filmRepository = filmRepository;
            }
            
            [HttpGet]
            public async Task<ActionResult<ICollection<Film>>> GetFilms()
            {
                return Ok(await _filmRepository.GetFilm());
            }

            [HttpGet("{film_Id}", Name = "GetFilm")]
            public async Task<ActionResult<Film>> GetFilmById(int film_Id)
            {

                return Ok(await _filmRepository.GetFilmById(film_Id));
            }


            [HttpPost]

            public async Task<ActionResult> CreateFilm([FromBody] Film film)
            {
                await _filmRepository.CreateFilm(film);
                return CreatedAtRoute("GetFilm", new
                {
                    film_Id = film.Film_ID
                }, film);
            }

            [HttpPut]

            public async Task<ActionResult> UpdateFilm([FromBody] Film film)
            {
                await _filmRepository.UpdateFilm(film);
                return NoContent();

            }

            [HttpDelete("{film_Id}")]

            public async Task<ActionResult> DeleteFilm(int filmId)
            {
                await _filmRepository.DeleteFilm(filmId);
                return NoContent();
            }
        }
    }

