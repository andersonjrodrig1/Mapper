using AutoMapper;
using Demo.Mapper.Api.Entities;
using Demo.Mapper.Api.ViewModel;

namespace Demo.Mapper.Api.Mappers
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<ClientViewModel, Client>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Cod_Client))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.First_Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.Last_Name))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.Birth_Date))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z));

            CreateMap<ClientViewModel, Gender>()
                .ForMember(x => x.Descrition, y => y.MapFrom(z => z.Gender_Name));

            CreateMap<Client, ClientViewModel>()
                .ForMember(x => x.Cod_Client, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.First_Name, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.Last_Name, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Birth_Date, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Gender_Name, y => y.MapFrom(z => z.Gender.Descrition));
        }
    }
}
