using Appli_Cinéma.Modele;
using Appli_Cinéma.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Controllers
{
    public class AvisController : Controller
    {
        private readonly IAvisRepository _avisRepository;

        public AvisController(IAvisRepository avisRepository)
        {
            _avisRepository = avisRepository;
        }
        [HttpGet]
        public ActionResult<ICollection<Avis>> GetAvis()
        {
            return Ok(_avisRepository.GetAvis());
        }

        [HttpGet("{Avis_Id}", Name = "GetAvis")]
        public ActionResult<Avis> GetAvisById(int avis_Id)
        {

            return Ok(_avisRepository.GetAvisById(avis_Id));
        }


        [HttpPost]

        public async Task<ActionResult> CreateAvis([FromBody] Avis avis)
        {
            await _avisRepository.CreateAvis(avis);
            return CreatedAtRoute("GetAvis", new
            {
                Avis_Id = avis.Avis_ID
            }, avis);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateAvis([FromBody] Avis avis)
        {
            await _avisRepository.UpdateAvis(avis);
            return NoContent();

        }

        [HttpDelete("{avis_Id}")]

        public async Task<ActionResult> DeleteAvis(int avis_Id)
        {
            await _avisRepository.DeleteAvis(avis_Id);
            return NoContent();
        }
    }
}
