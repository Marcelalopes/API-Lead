using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.Repository.Interfaces;

namespace API.Repository
{
    public class CollaboratorRepository: ICollaboratorRepository
    {
        private readonly AppDbContext _context;
        public CollaboratorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Collaborator> GetAll()
        {
            return _context.Collaborator.ToList();
        }

        public Collaborator SearchCpf(string cpf)
        {
            var coll = _context.Collaborator.First(c => c.CPF == cpf);
            return coll;
        }

        public Collaborator SearchName(string name)
        {
            var coll = _context.Collaborator.First(c => c.Name == name);
            return coll;
        }
        public Collaborator Add(Collaborator collaborator)
        {
            _context.Collaborator.Add(collaborator);
            _context.SaveChanges();
            return collaborator;
        }
        public void Update(Collaborator collaborator)
        {
            _context.Collaborator.Update(collaborator);
            _context.SaveChanges();
        }
    }
}