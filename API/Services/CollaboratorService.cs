using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;

namespace API.Services
{
    public class CollaboratorService
    {
        private readonly AppDbContext _context;

        public CollaboratorService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Collaborator> GetAllActive()
        {
            return _context.Collaborator.ToList().Where(x => x.isActive == true);
        }
        public IEnumerable<Collaborator> GetAllDisable()
        {
            return _context.Collaborator.ToList().Where(x => x.isActive == false);
        }
        public Collaborator GetByCpf(string cpf)
        {
            var coll = _context.Collaborator.First(c => c.CPF == cpf);
            return coll;
        }
        public Collaborator GetByName(string name)
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
        public Boolean Disable(string cpf)
        {
            var coll = _context.Collaborator.FirstOrDefault(x => x.CPF == cpf);
            if (coll == null)
                return false;
            if (coll.isActive == false)
                return false;
            coll.isActive = false;
            return true;
        }
        public Boolean Reactive(string cpf)
        {
            var coll = _context.Collaborator.FirstOrDefault(x => x.CPF == cpf);
            if (coll == null)
                return false;
            if (coll.isActive == true)
                return false;
            coll.isActive = true;
            return true;
        }
    }
}