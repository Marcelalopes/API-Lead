using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<CollaboratorDto> GetAllActive()
        {
            return _mapper.Map<IEnumerable<CollaboratorDto>>(_collaboratorRepository.GetAll().ToList().Where(x => x.isActive == true));
        }
        public IEnumerable<CollaboratorDto> GetAllDisable()
        {
            return _mapper.Map<IEnumerable<CollaboratorDto>>(_collaboratorRepository.GetAll().ToList().Where(x => x.isActive == false));
        }
        public CollaboratorDto GetByCpf(string cpf)
        {
            var coll = _mapper.Map<CollaboratorDto>(_collaboratorRepository.SearchCpf(cpf));
            return coll;
        }
        public CollaboratorDto GetByName(string name)
        {
            var coll = _mapper.Map<CollaboratorDto>(_collaboratorRepository.SearchName(name));
            return coll;
        }
        public CollaboratorNewDto Add(CollaboratorNewDto newCollaborator)
        {
            _collaboratorRepository.Add(_mapper.Map<Collaborator>(newCollaborator));
            return newCollaborator;
        }
        public void Update(CollaboratorUpdateDto updateCollaborator)
        {
            _collaboratorRepository.Update(_mapper.Map<Collaborator>(updateCollaborator));
        }
        public Boolean Disable(string cpf)
        {
            var coll = _collaboratorRepository.SearchCpf(cpf);
            if (coll == null)
                return false;
            if (coll.isActive == false)
                return false;
            coll.isActive = false;
            _collaboratorRepository.Update(coll);
            return true;
        }
        public Boolean Reactivate(string cpf)
        {
            var coll = _collaboratorRepository.SearchCpf(cpf);
            if (coll == null)
                return false;
            if (coll.isActive == true)
                return false;
            coll.isActive = true;
            _collaboratorRepository.Update(coll);
            return true;
        }
    }
}