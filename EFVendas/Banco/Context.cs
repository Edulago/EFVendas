using EFVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace EFVendas.Banco;

internal class Context : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItems { get; set; }
    public DbSet<Produto> Produto { get; set; }

    private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFVendas;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PedidoItem>()
            .HasOne(p => p.Pedido)
            .WithMany(p => p.PedidoItens) 
            .HasForeignKey(p => p.PedidoId);

        modelBuilder.Entity<PedidoItem>()
            .HasOne(p => p.Produto)
            .WithMany(p => p.PedidoItens)
            .HasForeignKey(p => p.ProdutoId);
    }
}
