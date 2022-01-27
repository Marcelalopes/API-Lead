using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<AddressDto> GetAll()
        {
            return _mapper.Map<IEnumerable<AddressDto>>(_addressRepository.GetAll().ToList());
        }
        public AddressDto SearchId(Guid id)
        {
            return _mapper.Map<AddressDto>(_addressRepository.Search(id));
        }
        public AddressNewDto Add(AddressNewDto newAddress)
        {
            _addressRepository.Add(_mapper.Map<Address>(newAddress));
            return newAddress;
        }
        public void Update(AddressNewDto updateAddress)
        {
            _addressRepository.Update(_mapper.Map<Address>(updateAddress));
        }
        public Boolean Disable(Guid id)
        {
            var address = _addressRepository.Search(id);
            if (address == null)
                return false;
            if (address.isActive == false)
                return false;
            address.isActive = false;
            _addressRepository.Update(address);
            return true;
        }
        public Boolean Reactivate(Guid id)
        {
            var address = _addressRepository.Search(id);
            if (address == null)
                return false;
            if (address.isActive == true)
                return false;
            address.isActive = true;
            _addressRepository.Update(address);
            return true;
        }
    }
}