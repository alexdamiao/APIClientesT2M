using Clientes.Api.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Tests.Contracts;

[TestFixture]
public class PutClienteRequestTest
{
    [Test]
    public void NomeEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            // Nome não é definido, o que deveria falhar na validação.
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Nome field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void NomeNaoEhMaiorQueTamanhoMaximo()
    {
        var request = new CreateClienteRequest
        {
            Nome = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ",
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The field Nome must be a string with a maximum length of 50.", results[0].ErrorMessage);
    }

    [Test]
    public void NascimentoEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            // Nascimento não é definido, o que deveria falhar na validação.
            Cpf = "47833146080",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("Nascimento está inválido.", results[0].ErrorMessage);
    }

    [Test]
    public void CpfEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            // Cpf não é definido, o que deveria falhar na validação.
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Cpf field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void CpfEhValido()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678900", // Cpf inválido
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("CPF inválido.", results[0].ErrorMessage);
    }

    [Test]
    public void EnderecoEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            // Endereco não é definido, o que deveria falhar na validação.
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Endereco field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void NumeroEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            Endereco = "Rua Teste 123",
            // Numero não é definido, o que deveria falhar na validação.
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Numero field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void BairroEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            Endereco = "Rua Teste 123",
            Numero = "123",
            // Bairro não é definido, o que deveria falhar na validação.
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Bairro field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void CidadeEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            // Cidade não é definido, o que deveria falhar na validação.
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Cidade field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void UfEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            // Uf não é definido, o que deveria falhar na validação.
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Uf field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void CepEhObrigatorio()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ"
            // Cep não é definido, o que deveria falhar na validação.
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("Cep está inválido.", results[0].ErrorMessage);
    }

    [Test]
    public void UfNaoEhMaiorQueTamanhoMaximo()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The field Uf must be a string with a maximum length of 2.", results[0].ErrorMessage);
    }

    [Test]
    public void ValidarUmaRequisicaoCompleta()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123",
            Numero = "123",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Uf = "RJ",
            Cep = 12345678
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsTrue(isValid);
        Assert.AreEqual(0, results.Count);
    }
}
