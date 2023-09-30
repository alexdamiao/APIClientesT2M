using Clientes.Api.Contracts;
using Clientes.Api.Controllers;
using Clientes.Api.Data;
using Clientes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Tests.Contracts;

[TestFixture]
public class ClienteControllerTests
{
    private ClienteController _controller;
    private ClienteContext _context;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ClienteContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ClienteContext(options);
        _controller = new ClienteController(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Test]
    public async Task Post_RequestValido_RetornaResponse201()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var response = await _controller.Post(request) as CreatedResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(201, response.StatusCode);
    }

    [Test]
    public async Task Get_IdExistente_RetornaResponse200()
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();

        var response = await _controller.Get(cliente.Id) as OkObjectResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.StatusCode);
    }

    [Test]
    public async Task Get_IdInexistente_RetornaResponse404()
    {
        var response = await _controller.Get(Guid.NewGuid()) as NotFoundResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(404, response.StatusCode);
    }

    [Test]
    public async Task Get_ListaTodos_RetornaResponse200()
    {
        _context.Cliente.Add(new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste 1",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        });

        _context.Cliente.Add(new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste 2",
            Nascimento = DateTime.Now,
            Cpf = "12345678902",
            Endereco = "Rua Teste 456",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        });

        await _context.SaveChangesAsync();

        var response = await _controller.Get() as OkObjectResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.StatusCode);

        var clientes = response.Value as IEnumerable<GetClienteResponse>;
        Assert.IsNotNull(clientes);
        Assert.AreEqual(2, clientes.Count());
    }

    [Test]
    public async Task Delete_IdExistente_RetornaResponse204()
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();

        var response = await _controller.Delete(cliente.Id) as NoContentResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(204, response.StatusCode);
    }

    [Test]
    public async Task Delete_IdInexistente_RetornaResponse404()
    {
        var response = await _controller.Delete(Guid.NewGuid()) as NotFoundResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(404, response.StatusCode);
    }

    [Test]
    public async Task Put_IdExistente_RetornaResponse200()
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();

        var request = new PutClienteRequest
        {
            Id = cliente.Id,
            Nome = "Nome Atualizado",
            Nascimento = DateTime.Now.AddDays(-1),
            Cpf = "98765432109",
            Endereco = "Nova Rua 456",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var response = await _controller.Put(request) as OkObjectResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.StatusCode);

        var updatedCliente = response.Value as PutClienteResponse;
        Assert.IsNotNull(updatedCliente);
        Assert.AreEqual(request.Id, updatedCliente.Id);
        Assert.AreEqual(request.Nome, updatedCliente.Nome);
        Assert.AreEqual(request.Nascimento, updatedCliente.Nascimento);
        Assert.AreEqual(request.Cpf, updatedCliente.Cpf);
        Assert.AreEqual(request.Endereco, updatedCliente.Endereco);
    }

    [Test]
    public async Task Put_IdInexistente_RetornaResponse201()
    {
        var request = new PutClienteRequest
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var response = await _controller.Put(request) as CreatedResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(201, response.StatusCode);
    }

    [Test]
    public async Task Put_RequestInvalido_RetornaResponse400()
    {
        var request = new PutClienteRequest();

        var response = await _controller.Put(request) as BadRequestObjectResult;
        Assert.IsNotNull(response);
        Assert.AreEqual(400, response.StatusCode);
    }
}
