using Appli_Cinéma.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public interface IFilmRepository
    {
        public Task<List<Film>> GetFilm();
        public Task<List<Film>> GetFilmC();
        public Task<List<Film>> GetFilmBySalle();
        public Task<Film> GetFilmById(int id);
        public Task CreateFilm(Film film);
        public Task DeleteFilm(Film film);
        public Task UpdateFilm(Film film);
    }
}
