using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using API.Dtos.Collaborator;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorDto>> GetAllActive();
        Task<IEnumerable<CollaboratorDto>> GetAllDisable();
        Task<CollaboratorDto> GetByCpf(string cpf);
        Task<CollaboratorDto> GetByName(string name);
        Task<CollaboratorNewDto> Add(CollaboratorNewDto collaborator);
        Task<Boolean> Update(CollaboratorUpdateDto collaborator, string cpf);
        Task<Boolean> Disable(string cpf);
        Task<Boolean> Reactivate(string cpf);
    }
}