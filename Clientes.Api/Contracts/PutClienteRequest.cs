using Clientes.Api.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Api.Contracts;

public class PutClienteRequest
{
    public Guid? Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; }

    [Required]
    [Nascimento]
    public DateTime Nascimento { get; set; }

    [Required]
    [StringLength(11)]
    [Cpf]
    public string Cpf { get; set; }

    [Required]
    [StringLength(100)]
    public string Endereco { get; set; }
}
