using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dtos.Collaborator;
using API.Models;
using API.Services;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;
        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpGet("getAllActive")]
        public async Task<ActionResult<IEnumerable<CollaboratorDto>>> GetAllActive()
        {
            return new ObjectResult(await _collaboratorService.GetAllActive());
        }

        [HttpGet("getAllDisable")]
        public async Task<ActionResult<IEnumerable<CollaboratorDto>>> GetAllDisable()
        {
            return new ObjectResult(await _collaboratorService.GetAllDisable());
        }

        [HttpGet("getByCpf/{cpf}:string")]
        public async Task<ActionResult<CollaboratorDto>> GetCpfCollaborator(string cpf)
        {
            return new ObjectResult(await _collaboratorService.GetByCpf(cpf));
        }

        [HttpGet("getByName/{name}:string")]
        public async Task<ActionResult<CollaboratorDto>> GetNameCollaborator(string name)
        {
            return new ObjectResult(await _collaboratorService.GetByName(name));
        }

        [HttpPost("add")]
        public async Task<ActionResult<CollaboratorNewDto>> AddCollaborator([FromBody] CollaboratorNewDto collaborator)
        {
            var result = await _collaboratorService.Add(collaborator);
            return new CreatedResult("", result);
        }

        [HttpPut("update/{cpf}:string")]
        public async Task<ActionResult> UpdateCollaborator([FromBody] CollaboratorUpdateDto collaborator, string cpf)
        {

            await _collaboratorService.Update(collaborator, cpf);
            return new OkObjectResult(collaborator);
        }

        [HttpDelete("disable/{cpf}:string")]
        public async Task<ActionResult> DisableCollaborator(string cpf)
        {
            var result = await _collaboratorService.Disable(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }

        [HttpPut("reactivate/{cpf}:string")]
        public async Task<ActionResult> ReactivateCollaborator(string cpf)
        {
            var result = await _collaboratorService.Reactivate(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}