using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dtos.Collaborator;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IMapper _mapper;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CollaboratorDto>> GetAllActive()
        {
            var result = await _collaboratorRepository.GetAll();
            return _mapper.Map<IEnumerable<CollaboratorDto>>(result).ToList().Where(x => x.isActive == true);
        }
        public async Task<IEnumerable<CollaboratorDto>> GetAllDisable()
        {
            var result = await _collaboratorRepository.GetAll();
            return _mapper.Map<IEnumerable<CollaboratorDto>>(result).ToList().Where(x => x.isActive == false);
        }
        public async Task<CollaboratorDto> GetByCpf(string cpf)
        {
            var result = await _collaboratorRepository.Search(x => x.CPF == cpf);
            if (result == null)
                return null;
            return _mapper.Map<CollaboratorDto>(result);
        }
        public async Task<CollaboratorDto> GetByName(string name)
        {
            var result = await _collaboratorRepository.Search(x => x.Name == name);
            if (result == null)
                return null;
            return _mapper.Map<CollaboratorDto>(result);
        }
        public async Task<CollaboratorNewDto> Add(CollaboratorNewDto newCollaborator)
        {
            var result = await _collaboratorRepository.Add(_mapper.Map<Collaborator>(newCollaborator));
            return _mapper.Map<CollaboratorNewDto>(result);
        }
        public async Task<Boolean> Update(CollaboratorUpdateDto updateCollaborator, string cpf)
        {
            var result = await _collaboratorRepository.Search(x => x.CPF == cpf);
            if (result == null)
                return false;

            result.Name = updateCollaborator.Name ?? result.Name;
            result.Gender = updateCollaborator.Gender ?? result.Gender;
            result.Phone = updateCollaborator.Phone ?? result.Phone;
            result.AddressId = updateCollaborator.AddressId ?? result.AddressId;

            await _collaboratorRepository.Update(result);
            return true;
        }
        public async Task<Boolean> Disable(string cpf)
        {
            var coll = await _collaboratorRepository.Search(x => x.CPF == cpf);
            if (coll == null)
                return false;
            if (coll.isActive == false)
                return false;
            coll.isActive = false;
            await _collaboratorRepository.Update(coll);
            return true;
        }
        public async Task<Boolean> Reactivate(string cpf)
        {
            var coll = await _collaboratorRepository.Search(x => x.CPF == cpf);
            if (coll == null)
                return false;
            if (coll.isActive == true)
                return false;
            coll.isActive = true;
            await _collaboratorRepository.Update(coll);
            return true;
        }
    }
}