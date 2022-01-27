using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressController()
        {
            _addressService = new AddressService();
        }

        [HttpGet("getAll")]
        public string GetAllAddress()
        {
            return _addressService.GetAll();
        }

        [HttpGet("searchId")]
        public string SearchIdAddress()
        {
            return _addressService.SearchId();
        }

        [HttpPost("add")]
        public Address AddAddress(Address address)
        {
            return _addressService.Add(address);
        }

        [HttpPut("update/{id}:Guid")]
        public string UpdateAddress()
        {
            return _addressService.Update();
        }

        [HttpDelete("disable/{id}:Guid")]
        public string DisableAddress()
        {
            return _addressService.Disable();
        }

        [HttpPut("reactivate/{id}:Guid")]
        public string ReactivateAddress()
        {
            return _addressService.Reactivate();
        }
    }
}