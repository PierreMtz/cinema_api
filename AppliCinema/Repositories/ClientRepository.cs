using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Modele;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CinemaDBContext _context;

        public ClientRepository(CinemaDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Client>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }
        public async Task<Client> GetClientById(int id)
        {
            return await _context.Client.Where(f => f.Client_ID == id).FirstOrDefaultAsync();
        }
        public async Task CreateClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(Client client)
        {
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            Client client = await GetClientById(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
