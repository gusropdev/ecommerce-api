using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;
using RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;
using RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;
using RO.DevTest.Application.Features.Product.Queries.GetAllProductsQuery;
using RO.DevTest.Application.Features.Product.Queries.GetProductByIdQuery;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController (IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
    {
        var result = await mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = result.ProductId }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request, Guid id)
    {
        if (id != request.ProductId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");
        
        var result = await mediator.Send(request);
        return Ok(result);  
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommandRequest request, Guid id)
    {
        if (id != request.ProductId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");

        var result = await mediator.Send(request);
        
        return Ok(result);   
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetProductByIdQueryRequest(id));
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }


}