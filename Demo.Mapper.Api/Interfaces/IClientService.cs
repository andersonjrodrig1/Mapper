using Demo.Mapper.Api.Entities;
using Demo.Mapper.Api.ViewModel;
using System.Collections.Generic;

namespace Demo.Mapper.Api.Interfaces
{
    public interface IClientService
    {
        Client ExecuteMapperToClient(ClientViewModel viewModel);
        ClientViewModel ExecuteMapperToClientViewModel(Client client);
        IEnumerable<Client> ExecuteMapperList(IEnumerable<ClientViewModel> viewsModel);
    }
}
