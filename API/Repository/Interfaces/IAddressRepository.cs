using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using API.Models;
using X.PagedList;
using API.Enum;

namespace API.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IPagedList<Address>> GetAll(int pageSize, int pageNumber, string search, OrderByTypeEnum orderByType, OrderByColumnAddressEnum orderByColumn);
        Task<Address> Search(Guid id);
        Task<Address> Add(Address address);
        Task<Boolean> Update(Address address);
    }
}