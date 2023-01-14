using MediatR;
using System.Collections.Generic;
using UpSchool_CQRS_DesignPatterns.CQRS.Results.UniversityResults;

namespace UpSchool_CQRS_DesignPatterns.CQRS.Queries.UniversityQueries;
public class GetAllUniversityQuery : IRequest<List<GetAllUniversityQueryResult>> { }
