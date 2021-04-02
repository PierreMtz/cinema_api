using Appli_Cinéma.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public interface ISalleRepository
    {
        public Task<List<Salle>> GetSalle();
        public Task<Salle> GetSalleById(int id);
        public Task CreateSalle(Salle salle);
        public Task DeleteSalle(int id);
        public Task UpdateSalle(Salle salle);
    }
}
