using System;
using System.Collections;
using System.Collections.Generic;
using API.Dtos.Address;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        Address SearchId (Guid id);
        AddressNewDto Add(AddressNewDto address);
        void Update(AddressNewDto address);
        Boolean Disable(Guid id);
        Boolean Reactivate(Guid id);
    }
}