using Clientes.Api.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Tests.Contracts;

[TestFixture]
public class CreateClienteRequestTests
{
    [Test]
    public void NomeIsRequired()
    {
        var request = new CreateClienteRequest
        {
            // Nome não é definido, o que deveria falhar na validação.
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Nome field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void NomeCannotExceedMaxLength()
    {
        var request = new CreateClienteRequest
        {
            Nome = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ",
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The field Nome must be a string with a maximum length of 50.", results[0].ErrorMessage);
    }

    [Test]
    public void NascimentoIsRequired()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            // Nascimento não é definido, o que deveria falhar na validação.
            Cpf = "47833146080",
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("Nascimento está inválido.", results[0].ErrorMessage);
    }

    [Test]
    public void CpfIsRequired()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            // Cpf não é definido, o que deveria falhar na validação.
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Cpf field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void CpfMustBeValid()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "12345678900", // Cpf inválido
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("CPF inválido.", results[0].ErrorMessage);
    }

    [Test]
    public void EnderecoIsRequired()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "51786638029",
            // Endereco não é definido, o que deveria falhar na validação.
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("The Endereco field is required.", results[0].ErrorMessage);
    }

    [Test]
    public void ValidRequestPassesValidation()
    {
        var request = new CreateClienteRequest
        {
            Nome = "Nome Teste",
            Nascimento = DateTime.Now,
            Cpf = "47833146080",
            Endereco = "Rua Teste 123"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsTrue(isValid);
        Assert.AreEqual(0, results.Count);
    }
}
