using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Dtos.Collaborator;
using API.Enum;
using API.Models;
using API.Repository.Interfaces;
using API.Services;
using AutoMapper;
using Moq;
using X.PagedList;
using Xunit;

namespace Tests.Services
{
    public class CollaboratorServiceTest
    {
        private readonly CollaboratorService _service;
        private readonly Mock<ICollaboratorRepository> _repository;
        private readonly Mock<IMapper> _mapper;

        public CollaboratorServiceTest()
        {
            _repository = new Mock<ICollaboratorRepository>();
            _mapper = new Mock<IMapper>();
            _service = new(_repository.Object, _mapper.Object);
        }

        [Fact]
        public void AddCollaborator_Ok()
        {
            CollaboratorNewDto collaboratorDto = new()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,07,09),
                Gender = "F",
                Phone = "86981425287",
                AddressId = Guid.NewGuid()
            };

            Collaborator collaborator = new Collaborator()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,07,09),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid(),
                Address = new Address(){
                    Id = Guid.NewGuid(),
                    Street = "Rua Projetada 01",
                    Number = "5",
                    District = "Villa",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            _repository.Setup(x => x.Add(It.IsAny<Collaborator>())).Returns(Task.FromResult(collaborator));
            _mapper.Setup(x => x.Map<CollaboratorNewDto>(It.IsAny<Collaborator>())).Returns(collaboratorDto);

            var result = _service.Add(collaboratorDto);

            Assert.NotNull(result.Result);
            Assert.Equal(collaborator.CPF, result.Result.CPF);
        }

        [Fact]
        public void AddCollaborator_CpfIsNotValidated()
        {
             CollaboratorNewDto collaboratorDto = new()
            {
                CPF = "06468786377",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,07,09),
                Gender = "F",
                Phone = "86981425287",
                AddressId = Guid.NewGuid()
            };

            Collaborator collaborator = new Collaborator()
            {
                CPF = "06468786377",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,07,09),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid(),
                Address = new Address(){
                    Id = Guid.NewGuid(),
                    Street = "Rua Projetada 01",
                    Number = "5",
                    District = "Villa",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            _repository.Setup(x => x.Add(It.IsAny<Collaborator>())).Returns(Task.FromResult(collaborator));
            _mapper.Setup(x => x.Map<CollaboratorNewDto>(It.IsAny<Collaborator>())).Returns(collaboratorDto);

            var exception = Assert.ThrowsAsync<Exception>(async () => {
                var result = await _service.Add(collaboratorDto);
            });

            Assert.Equal("CPF Invalid!.", exception.Result.Message);
        }

        [Fact]
        public void AddCollaborator_AgeInvalid()
        {
            CollaboratorNewDto collaboratorDto = new()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2005,07,09),
                Gender = "F",
                Phone = "86981425287",
                AddressId = Guid.NewGuid()
            };

            Collaborator collaborator = new Collaborator()
            {
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2005,07,09),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid(),
                Address = new Address(){
                    Id = Guid.NewGuid(),
                    Street = "Rua Projetada 01",
                    Number = "5",
                    District = "Villa",
                    City = "Pedro II",
                    State = "PI",
                    isActive = true
                }
            };

            _repository.Setup(x => x.Add(It.IsAny<Collaborator>())).Returns(Task.FromResult(collaborator));
            _mapper.Setup(x => x.Map<CollaboratorNewDto>(It.IsAny<Collaborator>())).Returns(collaboratorDto);

            var exception = Assert.ThrowsAsync<Exception>(async () => {
                var result = await _service.Add(collaboratorDto);
            });

            Assert.Equal("Collaborator is under 18 years of age!", exception.Result.Message);
        }

        [Theory]
        [InlineData("06468786380")]
        public void GetByCpf_OK(string cpf)
        {
            IEnumerable<Collaborator> collaborators = new List<Collaborator>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                    Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            IEnumerable<CollaboratorDto> collaboratorDtos = new List<CollaboratorDto>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                     Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns((Expression<Func<Collaborator, bool>> predicate)
                    => Task.FromResult(collaborators.ToList()
                        .FirstOrDefault(x => x.CPF == cpf)));

            _mapper.Setup(x => x.Map<CollaboratorDto>(It.IsAny<Collaborator>()))
            .Returns(collaboratorDtos.FirstOrDefault(x => x.CPF == cpf));

            var result = _service.GetByCpf(cpf);

            Assert.NotNull(result.Result);
        }


        [Theory]
        [InlineData("06468786380")]
        public void GetByCpf_NotFound(string cpf)
        {
            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(It.IsAny<Collaborator>()));
            _mapper.Setup(x => x.Map<CollaboratorDto>(It.IsAny<Collaborator>()))
            .Returns(It.IsAny<CollaboratorDto>());

           var result = _service.GetByCpf(cpf);

            Assert.Null(result.Result);
        }

        [Theory]
        [InlineData("Marcela dos Santos Lopes")]
        public void GetByName_OK(string name)
        {
            IEnumerable<Collaborator> collaborators = new List<Collaborator>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                    Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            IEnumerable<CollaboratorDto> collaboratorDtos = new List<CollaboratorDto>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                     Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns((Expression<Func<Collaborator, bool>> predicate)
                    => Task.FromResult(collaborators.ToList()
                        .FirstOrDefault(x => x.Name == name)));
            _mapper.Setup(x => x.Map<CollaboratorDto>(It.IsAny<Collaborator>()))
                .Returns(collaboratorDtos.FirstOrDefault(x => x.Name == name));

            var result = _service.GetByName(name);

            Assert.NotNull(result.Result);
        }

        [Theory]
        [InlineData("Antonio Mario")]
        public void GetByName_NotFound(string name)
        {
            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(It.IsAny<Collaborator>()));
            _mapper.Setup(x => x.Map<CollaboratorDto>(It.IsAny<Collaborator>()))
            .Returns(It.IsAny<CollaboratorDto>());

            var result = _service.GetByName(name);

            Assert.Null(result.Result);
        }

        [Theory]
        [InlineData(1,5,"",OrderByTypeEnum.ASC, OrderByColumnCollaboratorEnum.Name)]
        public void GetAllActive_Ok(
            int pageNumber, 
            int pageSize, 
            string search, 
            OrderByTypeEnum orderByType = OrderByTypeEnum.ASC, 
            OrderByColumnCollaboratorEnum orderByColumn = OrderByColumnCollaboratorEnum.Name
        )
        {
            IEnumerable<Collaborator> collaborators = new List<Collaborator>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                    Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            IEnumerable<CollaboratorDto> collaboratorDtos = new List<CollaboratorDto>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                     Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };
            
            _repository.Setup(x => 
            x.GetAll(pageNumber, pageSize, search, orderByType, orderByColumn))
            .Returns(Task.FromResult(collaborators.ToPagedList()));
            _mapper.Setup(x => 
            x.Map<IEnumerable<CollaboratorDto>>(It.IsAny<Collaborator>()))
            .Returns(collaboratorDtos);

            var result = _service.GetAllActive(pageNumber, pageSize, search, orderByType, orderByColumn);

            Assert.NotNull(result.Result);
        }

        [Theory]
        [InlineData(1,5,"",OrderByTypeEnum.ASC, OrderByColumnCollaboratorEnum.Name)]
        public void GetAllDisable_Ok(
            int pageNumber, 
            int pageSize, 
            string search, 
            OrderByTypeEnum orderByType = OrderByTypeEnum.ASC, 
            OrderByColumnCollaboratorEnum orderByColumn = OrderByColumnCollaboratorEnum.Name
        )
        {
            IEnumerable<Collaborator> collaborators = new List<Collaborator>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                    Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };

            IEnumerable<CollaboratorDto> collaboratorDtos = new List<CollaboratorDto>() {
                new() {
                    Name = "Marcela dos Santos Lopes",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2002,07,09),
                    CPF = "06468786380",
                    Phone = "86981425287",
                    Gender = "F",
                    isActive = true,
                },
                new() {
                    Name = "Luis João dos Santos",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2000,01,23),
                    CPF = "50425301001",
                    Phone = "64987246587",
                    Gender = "M",
                    isActive = true,
                },
                new() {
                     Name = "Maria da Silva Sousa",
                    AddressId = Guid.NewGuid(),
                    BirthDate = new DateTime(2001,8,4),
                    CPF = "61674823061",
                    Phone = "99999999999",
                    Gender = "F",
                    isActive = true,
                },
            };
            
            _repository.Setup(x => 
            x.GetAll(pageNumber, pageSize, search, orderByType, orderByColumn))
            .Returns(Task.FromResult(collaborators.ToPagedList()));
            _mapper.Setup(x => 
            x.Map<IEnumerable<CollaboratorDto>>(It.IsAny<Collaborator>()))
            .Returns(collaboratorDtos);

            var result = _service.GetAllDisable(pageNumber, pageSize, search, orderByType, orderByColumn);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public async void Update_Ok()
        {
            CollaboratorUpdateDto updateCollaborator = new(){
                Name = "Marcela Lopes",                
                Gender = "F",
                Phone = "86981425287",
                AddressId = Guid.NewGuid(),
            };

            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(new Collaborator(){
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",  
                BirthDate = new DateTime(2002,8,20),              
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid(),
            }));
            _repository.Setup(x => x.Update(It.IsAny<Collaborator>()))
            .Returns(Task.FromResult(true));

            Assert.True(await _service.Update(updateCollaborator, It.IsAny<string>()));
        }

        [Fact]
        public void Update_NotFound()
        {
            string cpf = "06468786380";

            _repository.Setup(x => x.Update(It.IsAny<Collaborator>()))
            .Returns(Task.FromResult(false));

            var result = _service.Update(new CollaboratorUpdateDto(), cpf);
            Assert.False(result.Result);
        }

        [Fact]
        public async void Disable_OK()
        {
            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(new Collaborator(){
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,7,9),
                Gender = "F",
                Phone = "86981425287",
                isActive = true,
                AddressId = Guid.NewGuid(),
            }));
            _repository.Setup(x => x.Update(It.IsAny<Collaborator>()))
            .Returns(Task.FromResult(true));

            Assert.True(await _service.Disable(It.IsAny<string>()));
        }

        [Theory]
        [InlineData("06468786390")]
        public async void Disable_NotFound(string cpf)
        {

            _repository.Setup(x => x.Update(It.IsAny<Collaborator>())).Returns(Task.FromResult(false));

            var result = await _service.Disable(It.IsAny<string>());

            Assert.False(result);
        }

        [Fact]
        public async void Reactive_OK()
        {
            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(new Collaborator(){
                CPF = "06468786380",
                Name = "Marcela dos Santos Lopes",
                BirthDate = new DateTime(2002,7,9),
                Gender = "F",
                Phone = "86981425287",
                isActive = false,
                AddressId = Guid.NewGuid(),
            }));
            _repository.Setup(x => x.Update(It.IsAny<Collaborator>()))
            .Returns(Task.FromResult(true));

            Assert.True(await _service.Reactivate(It.IsAny<string>()));
        }

        [Theory]
        [InlineData("06468786380")]
        public void Reactive_NotFound(string cpf)
        {
            _repository.Setup(x => x.Search(It.IsAny<Expression<Func<Collaborator, bool>>>()))
            .Returns(Task.FromResult(new Collaborator()));
            _repository.Setup(x => x.Update(It.IsAny<Collaborator>()))
            .Returns(Task.FromResult(false));

            var result = _service.Reactivate(cpf);

            Assert.False(result.Result);
        }
    }
}   