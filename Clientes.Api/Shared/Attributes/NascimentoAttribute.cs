using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class NascimentoAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            return date >= DateTime.Parse("1800-01-01") && date < DateTime.Now;
        }

        return false; // Not a DateTime value; consider it invalid.
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} está inválido.";
    }
}
