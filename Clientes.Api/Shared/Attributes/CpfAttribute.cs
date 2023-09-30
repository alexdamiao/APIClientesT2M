using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.Shared.Attributes;


[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public class CpfAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (!IsCpfValid(value.ToString())) return new ValidationResult("CPF inválido.");

        return ValidationResult.Success;
    }

    public static bool IsCpfValid(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        string valor = input.Replace(".", "").Replace("-", "");

        if (valor.Length != 11)
            return false;

        bool igual = true;
        for (int i = 1; i < 11 && igual; i++)
            if (valor[i] != valor[0])
                igual = false;

        if (igual || valor == "12345678909")
            return false;

        int[] numeros = new int[11];

        for (int i = 0; i < 11; i++)
            numeros[i] = int.Parse(valor[i].ToString());

        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        int resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else
            if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }
}