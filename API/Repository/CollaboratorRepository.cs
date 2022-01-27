using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
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

        public async Task<Collaborator> Search(Expression<Func<Collaborator, bool>> predicate)
        {
            return await _context.Collaborator.FirstOrDefaultAsync(predicate);
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