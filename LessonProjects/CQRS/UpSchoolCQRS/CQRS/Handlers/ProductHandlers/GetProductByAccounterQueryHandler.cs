using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UpSchool_CQRS_DesignPatterns.CQRS.Results.ProductResults;
using UpSchool_CQRS_DesignPatterns.DAL.Context;

namespace UpSchool_CQRS_DesignPatterns.CQRS.Handlers.ProductHandlers;
public class GetProductByAccounterQueryHandler
{ 
    private readonly ProductContext _productContext;   

    public GetProductByAccounterQueryHandler(ProductContext productContext)
    {
        _productContext = productContext;
    } 
    public List<GetProductByAccounterQueryResult> Handle()
    { 
        var values = _productContext.Products.Select(x => new GetProductByAccounterQueryResult
        {
            ProductID = x.ProductID,
            Name = x.Name,
            Stock = x.Stock,
            Brand = x.Brand,
            SalePrice = x.SalePrice,
            PurchasePrice = x.PurchasePrice

        }).AsNoTracking().ToList(); 
        return values;
    } 
}
