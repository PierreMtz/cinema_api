using Appli_Cinéma.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public interface INourritureRepository
    {
        public Task<List<Nourriture>> GetNourriture();
        public Task<Nourriture> GetNourritureById(int id);
        public Task CreateNourriture(Nourriture nourriture);
        public Task DeleteNourriture(int id);
        public Task UpdateNourriture(Nourriture Nourriture);
    }
}
