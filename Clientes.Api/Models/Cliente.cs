using Clientes.Api.Contracts;

namespace Clientes.Api.Models
{

    public class Cliente
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

        public static Cliente From(CreateClienteRequest request)
        {
            return new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Nascimento = request.Nascimento,
                Cpf = request.Cpf,
                Endereco = request.Endereco,
                Numero = request.Numero,
                Complemento = request.Complemento, 
                Uf = request.Uf,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Cep = request.Cep
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
                Endereco = request.Endereco,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Uf = request.Uf,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Cep = request.Cep
            };
        }

        public Cliente With(PutClienteRequest request)
        {
            Nome = request.Nome;
            Nascimento = request.Nascimento;
            Cpf = request.Cpf;
            Endereco = request.Endereco;
            Numero = request.Numero;
            Complemento = request.Complemento;
            Uf = request.Uf;
            Cidade = request.Cidade;
            Bairro = request.Bairro;
            Cep = request.Cep;

            return this;
        }
    }
}