using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;
using RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest request, string id)
    {
        if (id != request.UserId)
            return BadRequest("ID do cliente no corpo não bate com o da URL");
        
        var result = await  mediator.Send(request);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        return Ok($"Simulação de busca por cliente por Id: {id}");
    }

}