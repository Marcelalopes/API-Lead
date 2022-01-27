using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using API.Models;
using System.Linq.Expressions;

namespace API.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetAll();
        Task<Collaborator> Search(Expression<Func<Collaborator, bool>> predicate);
        Task<Collaborator> Add(Collaborator collaborator);
        Task<Boolean> Update(Collaborator collaborator);
    }
}