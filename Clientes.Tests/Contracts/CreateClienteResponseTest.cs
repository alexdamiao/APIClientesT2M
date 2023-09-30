using Clientes.Api.Contracts;
using Clientes.Api.Models;

namespace Clientes.Tests.Contracts;

[TestFixture]
public class CreateClienteResponseTest
{
    [Test]
    public void FromVerificaAsPropriedadesCorretamente()
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = "Nome Teste",
            Nascimento = DateTime.Parse("1990-01-01"),
            Cpf = "12345678901",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Complemento = "Apto 456",
            Bairro = "Bairro Teste",
            Cidade = "Cidade Teste",
            Uf = "UF",
            Cep = 12345678
        };

        var response = CreateClienteResponse.From(cliente);

        Assert.AreEqual(cliente.Id, response.Id);
        Assert.AreEqual(cliente.Nome, response.Nome);
        Assert.AreEqual(cliente.Nascimento, response.Nascimento);
        Assert.AreEqual(cliente.Cpf, response.Cpf);
        Assert.AreEqual(cliente.Endereco, response.Endereco);
        Assert.AreEqual(cliente.Numero, response.Numero);
        Assert.AreEqual(cliente.Complemento, response.Complemento);
        Assert.AreEqual(cliente.Bairro, response.Bairro);
        Assert.AreEqual(cliente.Cidade, response.Cidade);
        Assert.AreEqual(cliente.Uf, response.Uf);
        Assert.AreEqual(cliente.Cep, response.Cep);
    }
}
