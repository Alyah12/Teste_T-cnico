using Microsoft.EntityFrameworkCore;
using Teste_Iboss.Models;

namespace Teste_Iboss.Context;

public class AppDbContext : DbContext
{
 public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
 public DbSet<Curse>? Curses { get; set; }
 public DbSet<Student> Students { get; set; }
}