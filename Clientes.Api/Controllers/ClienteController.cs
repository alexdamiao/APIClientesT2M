using Clientes.Api.Contracts;
using Clientes.Api.Data;
using Clientes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _clienteContext;
    public ClienteController(ClienteContext clienteContext)
    {
        _clienteContext = clienteContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateClienteRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entity = Cliente.From(request);
        await _clienteContext.Cliente.AddAsync(entity);
        await _clienteContext.SaveChangesAsync();

        return Created("api/cliente", CreateClienteResponse.From(entity));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var entity = await _clienteContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null) return NotFound();

        return Ok(GetClienteResponse.From(entity));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _clienteContext.Cliente.ToListAsync();

        if (entities == null) return NotFound();

        return Ok(entities.Select(entity => GetClienteResponse.From(entity)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var entity = await _clienteContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null) return NotFound();

        _clienteContext.Cliente.Remove(entity);
        await _clienteContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PutClienteRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entity = await _clienteContext.Cliente.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            entity = Cliente.From(request);

            _clienteContext.Cliente.Add(entity);
            await _clienteContext.SaveChangesAsync();

            return Created("api/cliente", PutClienteResponse.From(entity));
        }

        _clienteContext.Cliente.Update(entity.With(request));
        await _clienteContext.SaveChangesAsync();

        return Ok(PutClienteResponse.From(entity));
    }
}
