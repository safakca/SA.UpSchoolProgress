namespace UpSchool_CQRS_DesignPatterns.CQRS.Queries.ProductQueries;
public class GetProductHumanResourceByIDQuery
{
    public GetProductHumanResourceByIDQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
