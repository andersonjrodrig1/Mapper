using AutoMapper;
using Demo.Mapper.Api.Entities;
using Demo.Mapper.Api.Interfaces;
using Demo.Mapper.Api.Services;
using Demo.Mapper.Api.ViewModel;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.Mapper.Test.Services
{
    [Collection("ClientService")]
    public class ClientServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly IClientService _clientService;
        private readonly Client _client;
        private readonly ClientViewModel _clientViewModel;
        private readonly IEnumerable<Client> _clients;

        public ClientServiceTest()
        {
            _clientViewModel = new ClientViewModel
            {
                Cod_Client = 1,
                First_Name = "Maria da Silva",
                Last_Name = "Sauro",
                Birth_Date = DateTime.Parse("1985-10-15"),
                Gender_Name = "Feminino"
            };

            _client = new Client
            {
                Id = 1,
                FirstName = "Maria da Silva",
                LastName = "Sauro",
                BirthDate = DateTime.Parse("1985-10-15"),
                Gender = new Gender
                {
                    Descrition = "Feminino"
                }
            };

            _clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "João da Silva",
                    LastName = "Sauro",
                    BirthDate = DateTime.Parse("1985-10-15"),
                    Gender = new Gender
                    {
                        Descrition = "Masculino"
                    }
                },
                new Client
                {
                    Id = 1,
                    FirstName = "Maria da Silva",
                    LastName = "Sauro",
                    BirthDate = DateTime.Parse("1985-10-15"),
                    Gender = new Gender
                    {
                        Descrition = "Feminino"
                    }
                }
            };

            _mapperMock = new Mock<IMapper>();

            _mapperMock.Setup(m => m.Map<Client>(It.IsAny<ClientViewModel>()))
                       .Returns((ClientViewModel viewModel) => new Client
                       {
                           Id = viewModel.Cod_Client,
                           FirstName = viewModel.First_Name,
                           LastName = viewModel.Last_Name,
                           BirthDate = viewModel.Birth_Date,
                           Gender = new Gender
                           {
                               Descrition = viewModel.Gender_Name
                           }
                       });

            _mapperMock.Setup(m => m.Map<ClientViewModel>(It.IsAny<Client>()))
                       .Returns((Client client) => new ClientViewModel
                       {
                           Cod_Client = client.Id,
                           First_Name = client.FirstName,
                           Last_Name = client.LastName,
                           Birth_Date = client.BirthDate,
                           Gender_Name = client.Gender.Descrition
                       });

            _mapperMock.Setup(m => m.Map<IEnumerable<Client>>(It.IsAny<IEnumerable<ClientViewModel>>()))
                       .Returns((List<ClientViewModel> viewModels) => new List<Client>
                       {
                            new Client
                            {
                                Id = 1,
                                FirstName = "João da Silva",
                                LastName = "Sauro",
                                BirthDate = DateTime.Parse("1985-10-15"),
                                Gender = new Gender
                                {
                                    Descrition = "Masculino"
                                }
                            },
                            new Client
                            {
                                Id = 1,
                                FirstName = "Maria da Silva",
                                LastName = "Sauro",
                                BirthDate = DateTime.Parse("1985-10-15"),
                                Gender = new Gender
                                {
                                    Descrition = "Feminino"
                                }
                            }
                       });

            _clientService = new ClientService(_mapperMock.Object);
        }

        [Fact]
        public void Should_Be_Execute_Mapper_To_Client_Test()
        {
            //arrange
            var viewModel = new ClientViewModel
            {
                Cod_Client = 1,
                First_Name = "Maria da Silva",
                Last_Name = "Sauro",
                Birth_Date = DateTime.Parse("1985-10-15"),
                Gender_Name = "Feminino"
            };

            //act
            var result = _clientService.ExecuteMapperToClient(viewModel);

            //assert
            result.Should().BeEquivalentTo(_client);
        }

        [Fact]
        public void Should_Be_Execute_Mapper_To_ClientViewModel_Test()
        {
            //arrange
            var client = new Client
            {
                Id = 1,
                FirstName = "Maria da Silva",
                LastName = "Sauro",
                BirthDate = DateTime.Parse("1985-10-15"),
                Gender = new Gender
                {
                    Descrition = "Feminino"
                }
            };

            //act
            var result = _clientService.ExecuteMapperToClientViewModel(client);

            //assert
            result.Should().BeEquivalentTo(_clientViewModel);
        }

        [Fact]
        public void Should_Be_Execute_Mapper_List_Test()
        {
            //arrange
            var viewsModels = new List<ClientViewModel>
            {
                new ClientViewModel
                {
                    Cod_Client = 1,
                    First_Name = "João da Silva",
                    Last_Name = "Sauro",
                    Birth_Date = DateTime.Parse("1985-10-15"),
                    Gender_Name = "Masculino"
                },
                new ClientViewModel
                {
                    Cod_Client = 1,
                    First_Name = "Maria da Silva",
                    Last_Name = "Sauro",
                    Birth_Date = DateTime.Parse("1985-10-15"),
                    Gender_Name = "Feminino"
                }
            };

            //act
            var result = _clientService.ExecuteMapperList(viewsModels);

            //assert
            result.Should().BeEquivalentTo(_clients);
        }
    }
}
