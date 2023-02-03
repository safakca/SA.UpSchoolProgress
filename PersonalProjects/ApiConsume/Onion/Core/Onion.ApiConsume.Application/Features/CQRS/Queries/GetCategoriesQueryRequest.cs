using MediatR;
using Onion.ApiConsume.Application.Dtos;

namespace Onion.ApiConsume.Application.Features.CQRS.Queries;
public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>> { }
