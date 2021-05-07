using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli_Cinéma.Modele;

namespace Appli_Cinéma.Repositories
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClient();
        public Task<Client> GetClientById(int id);
        public Task CreateClient(Client Client);
        public Task DeleteClient(int id);
        public Task UpdateClient(Client Client);
    }
}
