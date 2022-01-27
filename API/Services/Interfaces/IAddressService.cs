using System;
using System.Collections;
using System.Collections.Generic;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        Address SearchId (Guid id);
        Address Add(Address address);
        void Update(Address address);
        Boolean Disable(Guid id);
        Boolean Reactivate(Guid id);
    }
}