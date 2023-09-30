using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class CepAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is int integer)
        {
            return integer >= int.MinValue && integer <= int.MaxValue && integer != 0;
        }

        return false; // Not a int value; consider it invalid.
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} está inválido.";
    }
}
