using Clientes.Api.Models;

namespace Clientes.Api.Contracts;

public class PutClienteResponse
{
    public Guid? Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }

    public static PutClienteResponse From(Cliente entity)
    {
        return new PutClienteResponse
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Nascimento = entity.Nascimento,
            Cpf = entity.Cpf,
            Endereco = entity.Endereco
        };
    }
}
