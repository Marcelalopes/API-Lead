using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.Services;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Address>> GetAllAddress()
        {
            return new ObjectResult(_addressService.GetAll().ToList());
        }

        [HttpGet("searchId")]
        public ActionResult<Address> SearchIdAddress(Guid id)
        {
            return new ObjectResult(_addressService.SearchId(id));
        }

        [HttpPost("add")]
        public ActionResult<Address> AddAddress([FromBody] Address address)
        {
            var result = _addressService.Add(address);
            return new CreatedResult("", result);
        }

        [HttpPut("update/{id}:Guid")]
        public ActionResult UpdateAddress([FromBody] Address address, Guid id)
        {
            if (id != address.Id)
                return new BadRequestResult();

            _addressService.Update(address);
            return new OkObjectResult(address);
        }

        [HttpDelete("disable/{id}:Guid")]
        public ActionResult DisableAddress(Guid id)
        {
            var result = _addressService.Disable(id);
            return result ? new OkResult() : new NotFoundResult();
        }

        [HttpPut("reactivate/{id}:Guid")]
        public ActionResult ReactivateAddress(Guid id)
        {
            var result = _addressService.Reactivate(id);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}