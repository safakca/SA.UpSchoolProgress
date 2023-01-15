using AutoMapper;
using CrmProject.DTOLayer.DTOs.ContactDTOs;
using CrmProject.DTOLayer.DTOs.CustomerDTOs;
using CrmProject.EntityLayer.Concrete;

namespace CrmProject.UILayer.Mapping.AutoMapperProfile;
public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<ContactAddDTO, Contact>();
        CreateMap<Contact, ContactAddDTO>();

        CreateMap<ContactListDTO, Contact>();
        CreateMap<Contact, ContactListDTO>();

        CreateMap<ContactUpdateDTO, Contact>();
        CreateMap<Contact, ContactUpdateDTO>();

        CreateMap<CustomerAddDTO, Customer>();
        CreateMap<Customer, CustomerAddDTO>();
    }
}
