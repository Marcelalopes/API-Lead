using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<Address> Search(Guid id)
        {
            return await _context.Address.FirstAsync(x => x.Id == id);
        }

        public async Task<Address> Add(Address address)
        {
            var result = await _context.Address.AddAsync(address);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Boolean> Update(Address address)
        {
            _context.Address.Update(address);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}