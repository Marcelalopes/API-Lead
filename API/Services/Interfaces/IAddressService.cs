using System.Threading.Tasks;
using System;
using API.Dtos.Address;
using API.Enum;

namespace API.Services.Interfaces
{
    public interface IAddressService
    {
        Task<dynamic> GetAll(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnAddressEnum orderByColumn);
        Task<AddressDto> SearchId (Guid id);
        Task<AddressNewDto> Add(AddressNewDto address);
        Task<Boolean> Update(AddressNewDto address, Guid id);
        Task<Boolean> Disable(Guid id);
        Task<Boolean> Reactivate(Guid id);
    }
}