using System.Linq.Expressions;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Product.Queries.GetAllProductsQuery;

public class GetAllProductsQueryHandler (IProductRepository productRepository)
    : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsResult>
{
    public async Task<GetAllProductsResult> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var filter = BuildFilter(request.SearchTerm);
        var orderBy = BuildOrderBy(request.OrderBy, request.Ascending);
        
        var totalCount = await productRepository.CountAsync(filter);
        
        var products = await productRepository.GetAllAsync(
            filter, 
            orderBy,
            (request.PageNumber - 1) * request.PageSize,
            request.PageSize);
        
        return new GetAllProductsResult(totalCount, products);
    }
    
    private static Expression<Func<Domain.Entities.Product, bool>> BuildFilter(string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return p => true;

        return p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm);
    }
    private static Func<IQueryable<Domain.Entities.Product>, IOrderedQueryable<Domain.Entities.Product>> BuildOrderBy(string? orderBy, bool ascending)
    
    {
        return orderBy?.ToLower() switch
        {
            "name" => ascending 
                ? q => q.OrderBy(p => p.Name)
                : q => q.OrderByDescending(p => p.Name),
            "price" => ascending
                ? q => q.OrderBy(p => p.Price)
                : q => q.OrderByDescending(p => p.Price),
            "stock" => ascending
                ? q => q.OrderBy(p => p.StockQuantity)
                : q => q.OrderByDescending(p => p.StockQuantity),
            
            _ => q => q.OrderBy(p => p.Id)
        };
    }
}