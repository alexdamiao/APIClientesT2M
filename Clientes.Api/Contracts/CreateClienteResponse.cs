using Clientes.Api.Models;
using Clientes.Api.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.Contracts;

public class CreateClienteResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public int Cep { get; set; }

    public static CreateClienteResponse From(Cliente entity)
    {
        return new CreateClienteResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Nascimento = entity.Nascimento,
            Cpf = entity.Cpf,
            Endereco = entity.Endereco,
            Numero = entity.Numero,
            Cep = entity.Cep,
            Uf = entity.Uf,
            Cidade = entity.Cidade,
            Bairro = entity.Bairro,
            Complemento = entity.Complemento
        };
    }
}
