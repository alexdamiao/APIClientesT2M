using Clientes.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Api.Data.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Nascimento).IsRequired();
        builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
        builder.Property(p => p.Endereco).HasMaxLength(100).IsRequired();
    }
}
