using AutoMapper;
using MediatR;
using Onion.ApiConsume.Application.Dtos;
using Onion.ApiConsume.Application.Features.CQRS.Queries;
using Onion.ApiConsume.Application.Interfaces;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Application.Features.CQRS.Handlers;
public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        List<Category> categories = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryListDto>>(categories);
    }
}
