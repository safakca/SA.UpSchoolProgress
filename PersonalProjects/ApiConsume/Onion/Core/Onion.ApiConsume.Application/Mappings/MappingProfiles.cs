using AutoMapper;
using Onion.ApiConsume.Application.Dtos;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Application.Mappings;
public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Category, CategoryListDto>().ReverseMap();
	}
}
