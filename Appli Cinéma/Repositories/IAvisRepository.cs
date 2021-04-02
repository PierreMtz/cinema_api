using Appli_Cinéma.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public interface IAvisRepository
    {
        public Task<List<Avis>> GetAvis();
        public Task<Avis> GetAvisById(int id);
        public Task CreateAvis(Avis avis);
        public Task DeleteAvis(int id);
        public Task UpdateAvis(Avis avis);
     
    }
}
