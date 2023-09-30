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

    [Required]
    [StringLength(10)]
    public string Numero { get; set; }

    [StringLength(20)]
    public string Complemento { get; set; }

    [Required]
    [StringLength(100)]
    public string Bairro { get; set; }

    [Required]
    [StringLength(100)]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    public string Uf { get; set; }

    [Required]
    public int Cep { get; set; }
}
