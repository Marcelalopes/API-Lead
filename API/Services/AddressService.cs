using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Dtos.Address;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<Address> GetAll()
        {
            return _addressRepository.GetAll().ToList();
        }
        public Address SearchId(Guid id)
        {
            return _addressRepository.Search(id);
        }
        public AddressNewDto Add(AddressNewDto newAddress)
        {
            Address address = new Address()
            {
                Street = newAddress.Street,
                Number = newAddress.Number,
                District = newAddress.District,
                City = newAddress.City,
                State = newAddress.State
            };
            _addressRepository.Add(address);
            return newAddress;
        }
        public void Update(AddressNewDto updateAddress)
        {
            Address address = new Address()
            {
                Street = updateAddress.Street,
                Number = updateAddress.Number,
                District = updateAddress.District,
                City = updateAddress.City,
                State = updateAddress.State
            };
            _addressRepository.Update(address);
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