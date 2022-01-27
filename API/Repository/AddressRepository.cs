using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.Repository.Interfaces;

namespace API.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Address.ToList();
        }

        public Address Search(Guid id)
        {
            return _context.Address.First(x => x.Id == id);
        }

        public Address Add(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
            return address;
        }

        public void Update(Address address)
        {
            _context.Address.Update(address);
            _context.SaveChanges();
        }
    }
}