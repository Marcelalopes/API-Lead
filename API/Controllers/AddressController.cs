using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dtos.Address;
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
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAllAddress()
        {
            return new ObjectResult(await _addressService.GetAll());
        }

        [HttpGet("searchId")]
        public async Task<ActionResult<AddressDto>> SearchIdAddress(Guid id)
        {
            return new ObjectResult(await _addressService.SearchId(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddressNewDto>> AddAddress([FromBody] AddressNewDto address)
        {
            var result = await _addressService.Add(address);
            return new CreatedResult("", result);
        }

        [HttpPut("update/{id}:Guid")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressNewDto address, Guid id)
        {
            await _addressService.Update(address, id);
            return new OkObjectResult(address);
        }

        [HttpDelete("disable/{id}:Guid")]
        public async Task<ActionResult> DisableAddress(Guid id)
        {
            var result = await _addressService.Disable(id);
            return result ? new OkResult() : new NotFoundResult();
        }

        [HttpPut("reactivate/{id}:Guid")]
        public async Task<ActionResult> ReactivateAddress(Guid id)
        {
            var result = await _addressService.Reactivate(id);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}