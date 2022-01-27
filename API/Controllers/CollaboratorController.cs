using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly CollaboratorService _collaboratorService;
        public CollaboratorController(AppDbContext context)
        {
            _collaboratorService = new CollaboratorService(context);
        }

        [HttpGet("getAllActive")]
        public ActionResult<IEnumerable<Collaborator>> GetAllActive()
        {
            return new ObjectResult(_collaboratorService.GetAllActive().ToList());
        }

        [HttpGet("getAllDisable")]
        public ActionResult<IEnumerable<Collaborator>> GetAllDisable()
        {
            return new ObjectResult(_collaboratorService.GetAllDisable().ToList());
        }

        [HttpGet("getByCpf/{cpf}:string")]
        public ActionResult<Collaborator> GetCpfCollaborator(string cpf)
        {
            return new ObjectResult(_collaboratorService.GetByCpf(cpf));
        }

        [HttpGet("getByName/{name}:string")]
        public ActionResult<Collaborator> GetNameCollaborator(string name)
        {
            return new ObjectResult(_collaboratorService.GetByName(name));
        }

        [HttpPost("add")]
        public ActionResult<Collaborator> AddCollaborator([FromBody] Collaborator collaborator)
        {
            var result = _collaboratorService.Add(collaborator);
            return new CreatedResult("", result);
        }

        [HttpPut("update/{cpf}:string")]
        public ActionResult UpdateCollaborator([FromBody] Collaborator collaborator, string cpf)
        {
            if (cpf != collaborator.CPF)
                return new BadRequestResult();

            _collaboratorService.Update(collaborator);
            return new OkObjectResult(collaborator);
        }

        [HttpDelete("disable/{cpf}:string")]
        public ActionResult DisableCollaborator(string cpf)
        {
            var result = _collaboratorService.Disable(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }

        [HttpPut("reactivate/{cpf}:string")]
        public ActionResult ReactivateCollaborator(string cpf)
        {
            var result = _collaboratorService.Reactive(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}