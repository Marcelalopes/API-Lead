using System;
using System.Collections.Generic;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address Search(Guid id);
        Address Add(Address address);
        void Update(Address address);
    }
}