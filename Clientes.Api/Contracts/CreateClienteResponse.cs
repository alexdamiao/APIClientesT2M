using Clientes.Api.Models;

namespace Clientes.Api.Contracts;

public class CreateClienteResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }

    public static CreateClienteResponse From(Cliente entity)
    {
        return new CreateClienteResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Nascimento = entity.Nascimento,
            Cpf = entity.Cpf,
            Endereco = entity.Endereco
        };
    }
}
