using Clientes.Api.Contracts;

namespace Clientes.Api.Models;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }

    public static Cliente From(CreateClienteRequest request) 
    {
        return new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Nascimento = request.Nascimento,
            Cpf = request.Cpf,
            Endereco = request.Endereco
        };
    }

    public static Cliente From(PutClienteRequest request)
    {
        return new Cliente
        {
            Id = request.Id ?? Guid.NewGuid(),
            Nome = request.Nome,
            Nascimento = request.Nascimento,
            Cpf = request.Cpf,
            Endereco = request.Endereco
        };
    }

    public Cliente With(PutClienteRequest request)
    {
        Nome = request.Nome;
        Nascimento = request.Nascimento; 
        Cpf = request.Cpf; 
        Endereco = request.Endereco; 

        return this;
    }
}
