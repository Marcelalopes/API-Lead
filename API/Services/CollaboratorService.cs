using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dtos.Collaborator;
using API.Enum;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using API_Dell.Validations;
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
        public async Task<dynamic> GetAllActive(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnCollaboratorEnum orderByColumn)
        {
            var result = await _collaboratorRepository.GetAll(pageSize, pageNumber, search, orderByType, orderByColumn);

            dynamic response = new ExpandoObject();
            response.currentPage = pageNumber;
            response.pageSize = pageSize;
            response.totalPages = Math.Ceiling((double)result.TotalItemCount / pageSize);
            response.totalItems = result.TotalItemCount;
            response.search = search;
            response.orderByType = orderByType;
            response.orderByColumn = orderByColumn;

            response.data = _mapper.Map<IEnumerable<CollaboratorDto>>(result).ToList().Where(x => x.isActive == true);

            return response;
        }
        public async Task<dynamic> GetAllDisable(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnCollaboratorEnum orderByColumn)
        {
            var result = await _collaboratorRepository.GetAll(pageSize, pageNumber, search, orderByType, orderByColumn);

            dynamic response = new ExpandoObject();
            response.currentPage = pageNumber;
            response.pageSize = pageSize;
            response.totalPages = Math.Ceiling((double)result.TotalItemCount / pageSize);
            response.totalItems = result.TotalItemCount;
            response.search = search;
            response.orderByType = orderByType;
            response.orderByColumn = orderByColumn;

            response.data = _mapper.Map<IEnumerable<CollaboratorDto>>(result).ToList().Where(x => x.isActive == false);

            return response;
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
            if (!Validations.isLegalAge(newCollaborator.BirthDate))
            {
                throw new Exception("Collaborator is under 18 years of age!");
            }
            if (!Validations.IsCpf(newCollaborator.CPF))
            {
                throw new Exception("CPF Invalid!.");
            }
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
                        
            return await _collaboratorRepository.Update(result);
        }
        public async Task<Boolean> Disable(string cpf)
        {
            var coll = await _collaboratorRepository.Search(x => x.CPF == cpf);

            if (coll == null)
                return false;

            if (coll.isActive == false)
                return false;

            coll.isActive = false;
           
            return  await _collaboratorRepository.Update(coll);
        }
        public async Task<Boolean> Reactivate(string cpf)
        {
            var coll = await _collaboratorRepository.Search(x => x.CPF == cpf);

            if (coll == null)
                return false;

            if (coll.isActive == true)
                return false;

            coll.isActive = true;       

            return await _collaboratorRepository.Update(coll);
        }
    }
}