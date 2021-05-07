using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Modele;
using Microsoft.EntityFrameworkCore;

namespace Appli_Cinéma.Repositories
{
    public class AvisRepository : IAvisRepository
    {
        private readonly CinemaDBContext _context;

        public AvisRepository(CinemaDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Avis>> GetAvis()
        {
            return await _context.Avis.ToListAsync();
        }
        public async Task<Avis> GetAvisById(int id)
        {
            return await _context.Avis.Where(f => f.Avis_ID == id).FirstOrDefaultAsync();
        }

        public async Task CreateAvis(Avis avis)
        {
            _context.Avis.Add(avis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAvis(Avis avis)
        {
            _context.Avis.Update(avis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAvis(int id)
        {
            Avis avis = await GetAvisById(id);
            _context.Avis.Remove(avis);
            await _context.SaveChangesAsync();
        }
    }
}
