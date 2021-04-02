using Appli_Cinéma.Modele;
using Appli_Cinéma.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Controllers
{
    [ApiController]
    [Route("nourritures")]
    public class NourritureController : Controller
    {
        private readonly INourritureRepository _nourritureRepository;

        public NourritureController(INourritureRepository nourritureRepository)
        {
            _nourritureRepository = nourritureRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Nourriture>>> GetNourriture()
        {
            return Ok(await _nourritureRepository.GetNourriture());
        }

        [HttpGet("{nourriture_Id}", Name = "GetNourriture")]
        public async Task<ActionResult<Nourriture>> GetNourritureById(int nourriture_Id)
        {

            return Ok(await _nourritureRepository.GetNourritureById(nourriture_Id));
        }
        [HttpPost]

        public async Task<ActionResult> CreateNourriture([FromBody] Nourriture nourriture)
        {
            await _nourritureRepository.CreateNourriture(nourriture);
            return CreatedAtRoute("GetNourriture", new
            {
                nourriture_Id = nourriture.Nourriture_ID
            }, nourriture);
        }
        [HttpPut]

        public async Task<ActionResult> UpdateNourriture([FromBody] Nourriture nourriture)
        {
            await _nourritureRepository.UpdateNourriture(nourriture);
            return NoContent();

        }

        [HttpDelete("{film_Id}")]

        public async Task<ActionResult> DeleteNourriture(int nourritureId)
        {
            await _nourritureRepository.DeleteNourriture(nourritureId);
            return NoContent();
        }
    }
}
