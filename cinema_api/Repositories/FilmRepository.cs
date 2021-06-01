using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Modele;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly CinemaDBContext _context;

        public FilmRepository(CinemaDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Film>> GetFilm()
        {
            return await _context.Film.ToListAsync();
        }
        public async Task<List<Film>> GetFilmC()
        {
            return await _context.Film.Where(f => f.Film_Nom.Contains('c')).ToListAsync();
        }
        public async Task<List<Film>> GetFilmBySalle()
        {
            return await _context.Film.OrderBy(f => f.Salle_ID).ToListAsync();

        }
        public async Task<Film> GetFilmById(int id)
        {
            return await _context.Film.Where(f => f.Film_ID == id).FirstOrDefaultAsync();
        }

        public async Task CreateFilm(Film film)
        {
            _context.Film.Add(film);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFilm(Film film)
        {
            _context.Film.Update(film);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilm(Film film)
        {
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}
