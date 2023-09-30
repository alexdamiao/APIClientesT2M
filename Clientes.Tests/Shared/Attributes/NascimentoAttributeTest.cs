using Clientes.Api.Contracts;
using Clientes.Api.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Tests.Shared.Attributes;

public class NascimentoAttributeTest
{
    [Test]
    public void NascimentoEhObrigatorio()
    {
        var request = new Mock
        {
            Teste = "Data errada"
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        Assert.IsFalse(isValid);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("Teste está inválido.", results[0].ErrorMessage);
    }

    public class Mock 
    {
        [Nascimento]
        public string Teste { get; set;}
    }
}
