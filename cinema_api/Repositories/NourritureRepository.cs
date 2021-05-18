using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Modele;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public class NourritureRepository : INourritureRepository
    {
        private readonly CinemaDBContext _context;

        public NourritureRepository(CinemaDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Nourriture>> GetNourriture()
        {
            return await _context.Nourriture.ToListAsync();
        }
        public async Task<Nourriture> GetNourritureById(int id)
        {
            return await _context.Nourriture.Where(f => f.Nourriture_ID == id).FirstOrDefaultAsync();
        }
        public async Task CreateNourriture(Nourriture nourriture)
        {
            _context.Nourriture.Add(nourriture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNourriture(Nourriture nourriture)
        {
            _context.Nourriture.Update(nourriture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNourriture(int id)
        {
            Nourriture nourriture = await GetNourritureById(id);
            _context.Nourriture.Remove(nourriture);
            await _context.SaveChangesAsync();
        }
    }
}
