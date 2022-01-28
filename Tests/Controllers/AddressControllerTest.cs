using System.Collections.Generic;
using API.Controllers;
using API.Dtos.Address;
using API.Services.Interfaces;
using API.Enum;
using Moq;
using Xunit;
using System.Threading.Tasks;
using X.PagedList;
using System;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace Tests.Controllers
{
    public class AddressControllerTest
    {
        private readonly AddressController _controller;
        private readonly Mock<IAddressService> _service;

        public AddressControllerTest()
        {
            _service = new Mock<IAddressService>();
            _controller = new AddressController(_service.Object);
        }

        [Fact]
        public async void AddAddress_OK()
        {
            AddressNewDto addressDto = new()
            {
                Street = "Rua Perfume de Gardênia",
                Number = "25",
                District = "Villa",
                City = "Pedro II",
                State = "PI"
            };

            _service.Setup(x => x.Add(addressDto))
            .Returns(Task.FromResult(addressDto));

            var result = await _controller.AddAddress(addressDto);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void SearchById_Ok()
        {
            Guid id = new("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.SearchId(id))
            .Returns(Task.FromResult(new AddressDto()));

            var result = _controller.SearchIdAddress(id);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void SearchById_NotFound()
        {
            Guid id = new("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.SearchId(It.IsAny<Guid>()));

            var result = _controller.SearchIdAddress(id);

            Assert.IsType<NotFoundResult>(result.Result.Result);
        }

        [Fact]
        public void UpdateAddress_OK()
        {
            AddressNewDto updateDto = new()
            {
                Street = "Rua Perfume de Gardênia",
                Number = "25",
                District = "Villa",
                City = "Pedro II",
                State = "PI"
            };

            _service.Setup(x => x.Update(updateDto, It.IsAny<Guid>()))
            .Returns(Task.FromResult(true));

            var result = _controller.UpdateAddress(updateDto, It.IsAny<Guid>());

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void UpdateAddress_NotFound()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.Update(It.IsAny<AddressNewDto>(), id))
            .Returns(Task.FromResult(false));

            var result = _controller.UpdateAddress(It.IsAny<AddressNewDto>(), It.IsAny<Guid>());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void DisableAddress_OK()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.Disable(id))
            .Returns(Task.FromResult(true));

            var result = _controller.DisableAddress(id);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void DisableAddress_NotNull()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.Disable(id))
            .Returns(Task.FromResult(false));

            var result = _controller.DisableAddress(It.IsAny<Guid>());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void ReactivateAddress_OK()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.Reactivate(id))
            .Returns(Task.FromResult(true));

            var result = _controller.ReactivateAddress(id);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void ReactivateAddress_NotNull()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _service.Setup(x => x.Reactivate(id))
            .Returns(Task.FromResult(false));

            var result = _controller.ReactivateAddress(It.IsAny<Guid>());

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}