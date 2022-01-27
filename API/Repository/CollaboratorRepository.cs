using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CollaboratorRepository: ICollaboratorRepository
    {
        private readonly AppDbContext _context;
        public CollaboratorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collaborator>> GetAll()
        {
            return await _context.Collaborator.ToListAsync();
        }

        public async Task<Collaborator> SearchCpf(string cpf)
        {
            var coll = await _context.Collaborator.FirstAsync(c => c.CPF == cpf);
            return coll;
        }

        public async Task<Collaborator> SearchName(string name)
        {
            var coll = await _context.Collaborator.FirstAsync(c => c.Name == name);
            return coll;
        }
        public async Task<Collaborator> Add(Collaborator collaborator)
        {
            var coll = await _context.Collaborator.AddAsync(collaborator);
            _context.SaveChanges();
            return coll.Entity;
        }
        public async Task<Boolean> Update(Collaborator collaborator)
        {
            _context.Collaborator.Update(collaborator);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}