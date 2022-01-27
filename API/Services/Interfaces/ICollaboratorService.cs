using System.Threading.Tasks;
using System;
using API.Dtos.Collaborator;
using X.PagedList;
using API.Enum;

namespace API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        Task<dynamic> GetAllActive(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnCollaboratorEnum orderByColumn);
        Task<dynamic> GetAllDisable(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnCollaboratorEnum orderByColumn);
        Task<CollaboratorDto> GetByCpf(string cpf);
        Task<CollaboratorDto> GetByName(string name);
        Task<CollaboratorNewDto> Add(CollaboratorNewDto collaborator);
        Task<Boolean> Update(CollaboratorUpdateDto collaborator, string cpf);
        Task<Boolean> Disable(string cpf);
        Task<Boolean> Reactivate(string cpf);
    }
}