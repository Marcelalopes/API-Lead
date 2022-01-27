using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dtos.Address;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            var result = await _addressRepository.GetAll();
            return _mapper.Map<IEnumerable<AddressDto>>(result).ToList();
        }
        public async Task<AddressDto> SearchId(Guid id)
        {
            var result = await _addressRepository.Search(id);
            if (result == null)
                throw new Exception("Address not found");
            return _mapper.Map<AddressDto>(result);
        }
        public async Task<AddressNewDto> Add(AddressNewDto newAddress)
        {
            var result = await _addressRepository.Add(_mapper.Map<Address>(newAddress));
            return _mapper.Map<AddressNewDto>(result);
        }
        public async Task<Boolean> Update(AddressNewDto updateAddress, Guid id)
        {
            var result = await _addressRepository.Search(id);
            if (result == null)
                return false;
            result.Street = updateAddress.Street ?? result.Street;
            result.Number = updateAddress.Number ?? result.Number;
            result.District = updateAddress.District ?? result.District;
            result.City = updateAddress.City ?? result.City;
            result.State = updateAddress.State ?? result.State;

            await _addressRepository.Update(result);
            return true;
        }
        public async Task<Boolean> Disable(Guid id)
        {
            var address = await _addressRepository.Search(id);
            if (address == null)
                return false;
            if (address.isActive == false)
                return false;
            address.isActive = false;
            await _addressRepository.Update(address);
            return true;
        }
        public async Task<Boolean> Reactivate(Guid id)
        {
            var address = await _addressRepository.Search(id);
            if (address == null)
                return false;
            if (address.isActive == true)
                return false;
            address.isActive = true;
            await _addressRepository.Update(address);
            return true;
        }
    }
}