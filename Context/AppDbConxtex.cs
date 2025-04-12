using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context;

public class AppDbConxtex : DbContext
{
    public AppDbConxtex(DbContextOptions<AppDbConxtex> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lanche> Lanches { get; set; }
}
