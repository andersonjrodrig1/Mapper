using AutoMapper;
using Demo.Mapper.Api.Entities;
using Demo.Mapper.Api.Interfaces;
using Demo.Mapper.Api.ViewModel;
using System.Collections.Generic;

namespace Demo.Mapper.Api.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;

        public ClientService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Client ExecuteMapperToClient(ClientViewModel viewModel) =>_mapper.Map<Client>(viewModel);

        public ClientViewModel ExecuteMapperToClientViewModel(Client client) => _mapper.Map<ClientViewModel>(client);

        public IEnumerable<Client> ExecuteMapperList(IEnumerable<ClientViewModel> viewModels) => _mapper.Map<IEnumerable<Client>>(viewModels);
    }
}
