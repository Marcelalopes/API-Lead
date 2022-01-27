using API.Repository.Interfaces;
using API.Services;
using AutoMapper;
using Moq;
using Xunit;
using System;
using API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using API.Enum;
using API.Dtos.Address;
using X.PagedList;

namespace Tests.Services
{
    public class AddressServiceTest
    {
        private readonly AddressService _service;
        private readonly Mock<IAddressRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public AddressServiceTest()
        {
            _repository = new Mock<IAddressRepository>();
            _mapper = new Mock<IMapper>();
            _service = new(_repository.Object, _mapper.Object);
        }

        [Theory]
        [InlineData(1,5,"", OrderByTypeEnum.ASC, OrderByColumnAddressEnum.Street)]
        public void GetAll_Ok(
            int pageNumber, 
            int pageSize, 
            string search, 
            OrderByTypeEnum orderByType = OrderByTypeEnum.ASC, 
            OrderByColumnAddressEnum orderByColumn = OrderByColumnAddressEnum.Street
        )
        {
            IEnumerable<Address> address = new List<Address>() {
                new() {
                    Id = new Guid(),
                    Street = "Rua Projetada K",
                    Number = "63",
                    City = "Pedro II",
                    State = "PI",
                    isActive = false
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Perfume de Gardênia",
                    Number = "25",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Irmãos Pereira",
                    Number = "1051",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            IEnumerable<AddressDto> addressDto = new List<AddressDto>() {
                new() {
                    Id = new Guid(),
                    Street = "Rua Projetada K",
                    Number = "63",
                    City = "Pedro II",
                    State = "PI",
                    isActive = false
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Perfume de Gardênia",
                    Number = "25",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Irmãos Pereira",
                    Number = "1051",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            _repository.Setup(x => x.GetAll(
                pageNumber,
                pageSize,
                search,
                orderByType,
                orderByColumn))
            .Returns(Task.FromResult(address.ToPagedList()));
            _mapper.Setup(x => x.Map<IEnumerable<AddressDto>>(It.IsAny<Address>()))
            .Returns(addressDto);

            var result = _service.GetAll(pageNumber, pageSize, search, orderByType, orderByColumn);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void AddAddress_Ok()
        {
            AddressNewDto addressNew = new()
            {
                Street = "Rua Perfume de Gardênia",
                Number = "25",
                District = "Villa",
                City = "Pedro II",
                State = "PI",
            }; 

            Address address = new()
            {
                Id = Guid.NewGuid(),
                Street = "Rua Perfume de Gardênia",
                Number = "25",
                District = "Villa",
                City = "Pedro II",
                State = "PI",
                isActive = true
            };

             _repository.Setup(x => x.Add(It.IsAny<Address>())).Returns(Task.FromResult(address));
             _mapper.Setup(x => x.Map<AddressNewDto>(It.IsAny<Address>())).Returns(addressNew);

            var result = _service.Add(addressNew);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public void AddAddress_Null()
        {
            _repository.Setup(x => x.Add(It.IsAny<Address>())).Returns(Task.FromResult(It.IsAny<Address>()));
            _mapper.Setup(x => x.Map<AddressNewDto>(It.IsAny<Address>())).Returns(It.IsAny<AddressNewDto>());

            var result =_service.Add(new AddressNewDto());
            Assert.Null(result.Result);
        }

        [Fact]
        public void SearchIdAddress_OK()
        {
            Guid id = new ("08d9df61-9cc7-4111-86a7-69f23d80b170");
            IEnumerable<Address> address = new List<Address>() {
                new() {
                    Id = new Guid(),
                    Street = "Rua Projetada K",
                    Number = "63",
                    City = "Pedro II",
                    State = "PI",
                    isActive = false
                },
                new() {
                    Id = id,
                    Street = "Rua Perfume de Gardênia",
                    Number = "25",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Irmãos Pereira",
                    Number = "1051",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            IEnumerable<AddressDto> addressDto = new List<AddressDto>() {
                new() {
                    Id = new Guid(),
                    Street = "Rua Projetada K",
                    Number = "63",
                    City = "Pedro II",
                    State = "PI",
                    isActive = false
                },
                new() {
                    Id = id,
                    Street = "Rua Perfume de Gardênia",
                    Number = "25",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                },
                new() {
                    Id = new Guid(),
                    Street = "Rua Irmãos Pereira",
                    Number = "1051",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            _repository.Setup(x => x.Search(It.IsAny<Guid>()))
            .Returns(Task.FromResult(address.ToList()
                         .FirstOrDefault(x => x.Id == id)));
            _mapper.Setup(x => x.Map<AddressDto>(It.IsAny<Address>()))
            .Returns(addressDto.FirstOrDefault(x => x.Id == id));

            var result = _service.SearchId(id);

            Assert.NotNull(result.Result);          
        }

        [Fact]
        public void SearchIdAddress_NotFound()
        {
            Guid id = new("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _repository.Setup(x => x.Search(It.IsAny<Guid>()))
            .Returns(Task.FromResult(It.IsAny<Address>()));
            _mapper.Setup(x => x.Map<AddressDto>(It.IsAny<Address>()))
            .Returns(It.IsAny<AddressDto>());

            var exception = Assert.ThrowsAsync<Exception>
            (async () => {
                var result = await _service.SearchId(id);
            });

            Assert.Equal("Address not found", exception.Result.Message);
        }

        [Fact]
        public async void UpdateAddress_OK()
        {
            AddressNewDto updateDto = new()
            {
                Street = "Rua Perfume de Gardênia",
                Number = "25",
                District = "Villa",
                City = "Pedro II",
                State = "PI"
            };

            _repository.Setup(x => x.Search(It.IsAny<Guid>()))
            .Returns(Task.FromResult(new Address(){
                Id = new Guid(),
                Street = "Rua Projetada 01",
                Number = "5",
                District = "Villa",
                City = "Pedro II",
                State = "PI",
                isActive = true
            }));
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(true));

            Assert.True(await _service.Update(updateDto, It.IsAny<Guid>()));
        }

        [Fact]
        public async void UpdateAddress_NotFound()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(false));
            Assert.False(await _service.Update(new AddressNewDto(), id));
        }

        [Fact]
        public void DisableAddress_OK()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");
            Address address = new()
            {
                Id = id,
                Street = "string",
                Number = "1",
                District = "string",
                City = "string",
                State = "PI"
            };
            _repository.Setup(x => x.Search(id))
            .Returns(Task.FromResult(address));
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(true));
            
            var result = _service.Disable(id);

            Assert.NotNull(result.Result);
            Assert.Equal(id, address.Id);
        }

        [Fact]
        public void DisableAddress_NotFound()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _repository.Setup(x => x.Search(id))
            .Returns(Task.FromResult(It.IsAny<Address>()));
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(true));

            var result = _service.Disable(id);
            Assert.False(result.Result);
        }

        [Fact]
        public void ReactivateAddress_OK()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");
            Address address = new()
            {
                Id = id,
                Street = "string",
                Number = "1",
                District = "string",
                City = "string",
                State = "MA"
            };
            _repository.Setup(x => x.Search(id))
            .Returns(Task.FromResult(address));
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(false));
            
            var result = _service.Reactivate(id);

            Assert.NotNull(result.Result);
            Assert.Equal(id, address.Id);
        }

        [Fact]
        public void ReactivateAddress_NotFound()
        {
            Guid id = new Guid("08d9df61-9cc7-4111-86a7-69f23d80b170");

            _repository.Setup(x => x.Search(id))
            .Returns(Task.FromResult(It.IsAny<Address>()));
            _repository.Setup(x => x.Update(It.IsAny<Address>()))
            .Returns(Task.FromResult(false));

            var result = _service.Reactivate(id);
            Assert.False(result.Result);
        }
    }
}