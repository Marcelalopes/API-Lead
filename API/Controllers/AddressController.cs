using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.Address;
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

        /// <summary> Listar todos os endereços </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="400"> ERROR: Parâmetro inválido </response>
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAllAddress()
        {
            return new ObjectResult(await _addressService.GetAll());
        }

        /// <summary> Listar endereços por Id </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="404"> ERROR: Endereço não encontrado </response>
        [HttpGet("searchId")]
        public async Task<ActionResult<AddressDto>> SearchIdAddress(Guid id)
        {
            return new ObjectResult(await _addressService.SearchId(id));
        }

        /// <summary> Cadastrar endereço </summary>
        /// <remarks>
        ///     Exemplo RequestBody:
        ///
        ///         {
        ///             "street": "Rua 7 de Setembro",
        ///             "number": "5B",
        ///             "district": "Centro",
        ///             "city": "Pedro II",
        ///             "state":"PI"
        ///         }
        ///
        /// </remarks>
        /// <response code="201"> Sucesso </response>
        /// <response code="400"> ERROR: Erro de validação </response>
        [HttpPost("add")]
        public async Task<ActionResult<AddressNewDto>> AddAddress([FromBody] AddressNewDto address)
        {
            var result = await _addressService.Add(address);
            return new CreatedResult("", result);
        }

        /// <summary> Atualizar endereço </summary>
        /// <remarks>
        ///     Exemplo RequestBody:
        ///
        ///         {
        ///             "street": "Rua 7 de Setembro",
        ///             "number": "5B",
        ///             "district": "Centro",
        ///             "city": "Pedro II",
        ///             "state":"PI"
        ///         }
        ///
        /// </remarks>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="400"> ERROR: Erro de validação </response>
        /// <response code="404"> ERROR: Endereço não encontrado </response>
        [HttpPut("update/{id}:Guid")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressNewDto address, Guid id)
        {
            await _addressService.Update(address, id);
            return new OkObjectResult(address);
        }

        /// <summary> Desativar um endereço </summary>
        /// <param name="id"> Id do endereço que será desativado </param>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="404"> ERROR: Endereço não encontrado </response>
        [HttpDelete("disable/{id}:Guid")]
        public async Task<ActionResult> DisableAddress(Guid id)
        {
            var result = await _addressService.Disable(id);
            return result ? new OkResult() : new NotFoundResult();
        }

        /// <summary> Reativa um endereço </summary>
        /// <param name="id"> Id do endereço que será reativado </param>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="404"> ERROR: Endereço não encontrado </response>
        [HttpPut("reactivate/{id}:Guid")]
        public async Task<ActionResult> ReactivateAddress(Guid id)
        {
            var result = await _addressService.Reactivate(id);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}