using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAll();
        Task<Address> Search(Guid id);
        Task<Address> Add(Address address);
        Task<Boolean> Update(Address address);
    }
}