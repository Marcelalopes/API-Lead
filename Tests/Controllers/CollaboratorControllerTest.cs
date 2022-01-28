using System.Threading.Tasks;
using System;
using API.Controllers;
using API.Dtos.Collaborator;
using API.Services.Interfaces;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers
{
    public class CollaboratorControllerTest
    {
        private readonly CollaboratorController _controller;
        private readonly Mock<ICollaboratorService> _service;

        public CollaboratorControllerTest()
        {
            _service = new Mock<ICollaboratorService>();
            _controller = new CollaboratorController(_service.Object);
        }

        [Fact]
        public void GetByCpfCollaborator_OK()
        {
            CollaboratorDto collaboratorDto = new()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid()
            };

            _service.Setup(x => x.GetByCpf(collaboratorDto.CPF))
            .Returns(Task.FromResult(collaboratorDto));

            var result = _controller.GetCpfCollaborator(collaboratorDto.CPF);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetByCpfCollaborator_NotFoud()
        {
            string cpf = "06468786380";

            _service.Setup(x => x.GetByCpf(It.IsAny<string>()))
            .Returns(Task.FromResult(It.IsAny<CollaboratorDto>()));

            var result = _controller.GetCpfCollaborator(cpf);

            Assert.IsType<NotFoundResult>(result.Result.Result);
        }

        [Fact]
        public void GetByNameCollaborator_OK()
        {
            CollaboratorDto collaboratorDto = new()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid()
            };

            _service.Setup(x => x.GetByName(collaboratorDto.Name))
            .Returns(Task.FromResult(collaboratorDto));

            var result = _controller.GetNameCollaborator(collaboratorDto.Name);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetByNameCollaborator_NotFoud()
        {
            string name = "Marcela dos Santos Lopes";

            _service.Setup(x => x.GetByName(It.IsAny<string>()))
            .Returns(Task.FromResult(It.IsAny<CollaboratorDto>()));

            var result = _controller.GetNameCollaborator(name);

            Assert.IsType<NotFoundResult>(result.Result.Result);
        }

        [Fact]
        public void AddCollaborator_OK()
        {
            CollaboratorNewDto collaboratorNewDto = new()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(),
                Gender = "F",
                Phone = "86981425287"
            };

            _service.Setup(x => x.Add(collaboratorNewDto))
            .Returns(Task.FromResult(collaboratorNewDto));

            var result = _controller.AddCollaborator(collaboratorNewDto);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void UpdateCollaborator_OK()
        {
            CollaboratorUpdateDto updateDto = new()
            {
                Name = "Marcela Lopes",
                Gender = "F",
                Phone = "86981425287",
            };

            _service.Setup(x => x.Update(updateDto, It.IsAny<string>()));

            var result = _controller.UpdateCollaborator(updateDto, It.IsAny<string>());

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void UpdateCollaborator_NotFound()
        {
            CollaboratorUpdateDto updateDto = new()
            {
                Name = "Marcela Lopes",
                Gender = "F",
                Phone = "86981425287",
            };

            _service.Setup(x => x.Update(updateDto, It.IsAny<string>()));

            var result = _controller.UpdateCollaborator(It.IsAny<CollaboratorUpdateDto>(), It.IsAny<string>());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void DisableCollaborator_OK()
        {
            string cpf = "06468786380";

            _service.Setup(x => x.Disable(cpf));

            var result = _controller.DisableCollaborator(cpf);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void DisableCollaborator_NotNull()
        {
            string cpf = "06468786380";

            _service.Setup(x => x.Disable(It.IsAny<string>()));

            var result = _controller.DisableCollaborator(cpf);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void ReactivateCollaborator_OK()
        {
            string cpf = "06468786380";

            _service.Setup(x => x.Reactivate(cpf));

            var result = _controller.ReactivateCollaborator(cpf);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void ReactivateCollaborator_NotNull()
        {
            string cpf = "06468786380";

            _service.Setup(x => x.Reactivate(It.IsAny<string>()));

            var result = _controller.ReactivateCollaborator(cpf);

            Assert.IsType<NotFoundResult>(result.Result);
        }

    }
}