using LanchesMac.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;

public class AppDbConxtex : IdentityDbContext<IdentityUser>
{
    public AppDbConxtex(DbContextOptions<AppDbConxtex> options) : base(options)
    {}

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
}
