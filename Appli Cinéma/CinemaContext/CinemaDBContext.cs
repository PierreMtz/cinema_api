using Appli_Cinéma.Modele;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.CinemaContext
{
    public class CinemaDBContext : IdentityDbContext<User, Role, Guid>
    {
        public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
        {

        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Avis> Avis { get; set; }
        public DbSet<Salle> Salle { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Nourriture> Nourriture { get; set; }
     
    }
}
