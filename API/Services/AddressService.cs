using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;

namespace API.Services
{
    public class AddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Address> GetAll()
        {
            return _context.Address.ToList();
        }
        public Address SearchId(Guid id)
        {
            var address = _context.Address.First(x => x.Id == id);
            return address;
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
        public Boolean Disable(Guid id)
        {
            var address = _context.Address.FirstOrDefault(x => x.Id == id);
            if(address == null)
                return false;
            if(address.isActive == false)
                return false;
            address.isActive = false;
            return true;
        }
        public Boolean Reactivate(Guid id)
        {
            var address = _context.Address.FirstOrDefault(x => x.Id == id);
            if(address == null)
                return false;
            if(address.isActive == true)
                return false;
            address.isActive = true;
            return true;
        }
    }
}