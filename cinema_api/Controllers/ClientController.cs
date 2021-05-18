using Appli_Cinéma.DTOs.Cinema;
using Appli_Cinéma.Modele;
using Appli_Cinéma.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Client>>> GetClient()
        {
            return Ok(await _clientRepository.GetClient());
        }

        [HttpGet("{client_Id}", Name = "GetClient")]
        public async Task<ActionResult<ClientDTO>> GetClientById(int client_Id)
        {
            Client client = await _clientRepository.GetClientById(client_Id);

            return Ok(_mapper.Map<ClientDTO>(client));
        }
        [HttpPost]

        public async Task<ActionResult> CreateClient([FromBody] ClientForCreateDTO client)
        {
            Client cliententity = _mapper.Map<Client>(client);
            await _clientRepository.CreateClient(cliententity);
            return CreatedAtRoute("GetClient", new
            {
                client_Id = cliententity.Client_ID
            }, client);
        }
        [HttpPut]

        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            await _clientRepository.UpdateClient(client);
            return NoContent();

        }

        [HttpDelete("{client_Id}")]

        public async Task<ActionResult> DeleteClient(int clientId)
        {
            await _clientRepository.DeleteClient(clientId);
            return NoContent();
        }

    }
}
