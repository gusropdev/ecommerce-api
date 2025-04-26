using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;
using RO.DevTest.Application.Features.Customer.Commands.DeleteCustomerCommand;
using RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;
using RO.DevTest.Application.Features.Customer.Queries.GetAllCustomersQuery;
using RO.DevTest.Application.Features.Customer.Queries.GetCustomerByIdQuery;

namespace RO.DevTest.WebApi.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class CustomerController (IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommandRequest request)
    {
        var result = await mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = result.UserId }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest request, Guid id)
    {
        if (id != request.CustomerId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");
        
        var result = await mediator.Send(request);
        return Ok(result);
    }
    

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommandRequest request, Guid id)
    {
        if (id != request.CustomerId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");
        
        var result = await mediator.Send(request);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCustomerByIdQueryRequest(id));
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomersQueryRequest request)
    {
        var result = await mediator.Send(request);
        
        return Ok(result);
    }
}