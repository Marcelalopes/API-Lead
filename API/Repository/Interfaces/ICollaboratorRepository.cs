using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using API.Models;
using System.Linq.Expressions;
using X.PagedList;
using API.Enum;

namespace API.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<IPagedList<Collaborator>> GetAll(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnCollaboratorEnum orderByColumn);
        Task<Collaborator> Search(Expression<Func<Collaborator, bool>> predicate);
        Task<Collaborator> Add(Collaborator collaborator);
        Task<Boolean> Update(Collaborator collaborator);
    }
}