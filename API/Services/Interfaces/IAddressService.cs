using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using API.Dtos.Address;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAll();
        Task<AddressDto> SearchId (Guid id);
        Task<AddressNewDto> Add(AddressNewDto address);
        Task<Boolean> Update(AddressNewDto address, Guid id);
        Task<Boolean> Disable(Guid id);
        Task<Boolean> Reactivate(Guid id);
    }
}