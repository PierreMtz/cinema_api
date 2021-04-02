using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Modele;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public class SalleRepository : ISalleRepository
    {
        private readonly CinemaDBContext _context;

        public SalleRepository(CinemaDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Salle>> GetSalle()
        {
            return await _context.Salle.ToListAsync();
        }
        public async Task<Salle> GetSalleById(int id)
        {
            return await _context.Salle.Where(f => f.Salle_ID == id).FirstOrDefaultAsync();
        }
        public async Task CreateSalle(Salle salle)
        {
            _context.Salle.Add(salle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalle(Salle salle)
        {
            _context.Salle.Update(salle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalle(int id)
        {
            Salle salle = await GetSalleById(id);
            _context.Salle.Remove(salle);
            await _context.SaveChangesAsync();
        }
    }
}
