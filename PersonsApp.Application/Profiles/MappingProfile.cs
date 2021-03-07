using AutoMapper;
using PersonsApp.Application.Features.ConnectedPersons.Commands.Create;
using PersonsApp.Application.Features.Persons.Commands.Change;
using PersonsApp.Application.Features.Persons.Commands.Create;
using PersonsApp.Application.Features.Persons.Queries.GetPersonDetails;
using PersonsApp.Application.Features.Persons.Queries.GetPersonList;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonListVm>().ReverseMap();


            CreateMap<Person, PersonVm>()
                .ForMember(x => x.City, y => y.MapFrom(z => z.City.Name))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender.Name));
            CreateMap<PhoneNumber, PhoneNumberDto>()
                .ForMember(x=> x.PhoneType, y=> y.MapFrom(z=> z.PhoneType.Name));
            CreateMap<PersonConnection, PersonConnectionDto>()
                .ForMember(x => x.ConnectionType, y => y.MapFrom(z => z.ConnectionType.Name))
                .ForMember(x => x.ConnectedPerson, y => y.MapFrom(z => $"{z.ConnectedPerson.FirstName} {z.ConnectedPerson.LastName}"));


            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<PhoneNumber, CreatePhoneNumberDto>().ReverseMap();

            CreateMap<Person, ChangePersonCommand>().ReverseMap();
            CreateMap<PhoneNumber, ChangePhoneNumberDto>().ReverseMap();

            CreateMap<PersonConnection, CreatePersonConnectionCommand>().ReverseMap();

        }
    }
}
