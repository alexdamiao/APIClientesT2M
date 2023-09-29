using Clientes.Api.Data.Mappings;
using Clientes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Api.Data;

public class ClienteContext : DbContext
{
    public ClienteContext(DbContextOptions options) : base(options) { }
    public DbSet<Cliente> Cliente { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfiguration(new ClienteMap());
        base.OnModelCreating(modelBuilder);
    }
}
