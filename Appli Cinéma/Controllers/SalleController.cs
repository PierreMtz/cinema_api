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
    [Route("salles")]
    public class SalleController : Controller
    {
        private readonly ISalleRepository _salleRepository;

        public SalleController(ISalleRepository salleRepository)
        {
            _salleRepository = salleRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Salle>>> GetSalle()
        {
            return Ok(await _salleRepository.GetSalle());
        }

        [HttpGet("{salle_Id}", Name = "GetSalle")]
        public async Task<ActionResult<Salle>> GetSalleById(int salle_Id)
        {

            return Ok(await _salleRepository.GetSalleById(salle_Id));
        }
        [HttpPost]

        public async Task<ActionResult> CreateSalle([FromBody] Salle salle)
        {
            await _salleRepository.CreateSalle(salle);
            return CreatedAtRoute("GetSalle", new
            {
                salle_Id = salle.Salle_ID
            }, salle);
        }
        [HttpPut]

        public async Task<ActionResult> UpdateSalle([FromBody] Salle salle)
        {
            await _salleRepository.UpdateSalle(salle);
            return NoContent();

        }

        [HttpDelete("{salle_Id}")]

        public async Task<ActionResult> DeleteSalle(int salleId)
        {
            await _salleRepository.DeleteSalle(salleId);
            return NoContent();
        }
    }
}
