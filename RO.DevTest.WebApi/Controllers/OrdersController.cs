using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;
using RO.DevTest.Application.Features.Order.Commands.DeleteOrderCommand;
using RO.DevTest.Application.Features.Order.Queries.GetAllOrdersQuery;
using RO.DevTest.Application.Features.Order.Queries.GetOrderByIdQuery;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Customer, Admin")]
public class OrdersController (IMediator mediator) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommandRequest request)
    {
        var result = await mediator.Send(request);
        
        return CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeleteOrderCommandRequest request, Guid id)
    {
        if (id != request.OrderId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");
        
        var result = await mediator.Send(request);
        
        return Ok(result);   
    }

    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetOrderByIdQueryRequest(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQueryRequest request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}