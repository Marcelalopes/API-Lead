using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.Collaborator;
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

        /// <summary> Listar todos os colaboradores ativos </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="400"> ERROR: Parâmetro inválido </response>
        [HttpGet("getAllActive")]
        public async Task<ActionResult<IEnumerable<CollaboratorDto>>> GetAllActive()
        {
            return new ObjectResult(await _collaboratorService.GetAllActive());
        }

        /// <summary> Listar todos os colaboradores desativados </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="400"> ERROR: Parâmetro inválido </response>
        [HttpGet("getAllDisable")]
        public async Task<ActionResult<IEnumerable<CollaboratorDto>>> GetAllDisable()
        {
            return new ObjectResult(await _collaboratorService.GetAllDisable());
        }

        /// <summary> Listar colaboradores por cpf </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="404"> ERROR: Colaborador não encontrado </response>
        [HttpGet("getByCpf/{cpf}:string")]
        public async Task<ActionResult<CollaboratorDto>> GetCpfCollaborator(string cpf)
        {
            return new ObjectResult(await _collaboratorService.GetByCpf(cpf));
        }

        /// <summary> Listar colaboradores por nome </summary>
        /// <response code="200"> Sucesso </response>
        /// <response code="404"> ERROR: Colaborador não encontrado </response>
        [HttpGet("getByName/{name}:string")]
        public async Task<ActionResult<CollaboratorDto>> GetNameCollaborator(string name)
        {
            return new ObjectResult(await _collaboratorService.GetByName(name));
        }

        /// <summary> Cadastrar colaborador </summary>
        /// <remarks>
        ///     Exemplo RequestBody:
        ///
        ///              {
        ///                 "cpf":"06568386290",
        ///                 "name":"Marcela dos Santos Lopes",
        ///                 "birthDate":"2021-12-28T13:55:50.061Z",
        ///                 "gender": "F",
        ///                 "phone":"86987435689",
        ///                 "addressId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///              }
        ///
        /// </remarks>
        /// <response code="201"> Sucesso </response>
        /// <response code="400"> ERROR: Erro de validação </response>
        [HttpPost("add")]
        public async Task<ActionResult<CollaboratorNewDto>> AddCollaborator([FromBody] CollaboratorNewDto collaborator)
        {
            var result = await _collaboratorService.Add(collaborator);
            return new CreatedResult("", result);
        }

        /// <summary> Atualizar collaborador </summary>
        /// <remarks>
        ///     Exemplo RequestBody:
        ///
        ///              {
        ///                 "name":"Marcela dos Santos Lopes",
        ///                 "gender": "F",
        ///                 "phone":"86987435689",
        ///                 "addressId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///              }
        ///
        /// </remarks>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="400"> ERROR: Erro de validação </response>
        /// <response code="404"> ERROR: Colaborador não encontrado </response>
        [HttpPut("update/{cpf}:string")]
        public async Task<ActionResult> UpdateCollaborator([FromBody] CollaboratorUpdateDto collaborator, string cpf)
        {

            await _collaboratorService.Update(collaborator, cpf);
            return new OkObjectResult(collaborator);
        }

        /// <summary> Desativar um colaborador </summary>
        /// <param name="cpf"> cpf do colaborador que será desativado </param>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="404"> ERROR: Colaborador não encontrado </response>
        [HttpDelete("disable/{cpf}:string")]
        public async Task<ActionResult> DisableCollaborator(string cpf)
        {
            var result = await _collaboratorService.Disable(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }

        /// <summary> Reativar um colaborador </summary>
        /// <param name="cpf"> cpf do colaborador que será reativado </param>
        /// <response code="204"> Sucesso: Sem conteúdo </response>
        /// <response code="404"> ERROR: Colaborador não encontrado </response>
        [HttpPut("reactivate/{cpf}:string")]
        public async Task<ActionResult> ReactivateCollaborator(string cpf)
        {
            var result = await _collaboratorService.Reactivate(cpf);
            return result ? new OkResult() : new NotFoundResult();
        }
    }
}