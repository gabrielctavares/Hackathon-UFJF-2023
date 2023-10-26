using Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hackathon.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

     public DbSet<Endereco> Endereco { get; set; }
        
     public DbSet<Pessoa> Pessoa { get; set; }
        
     public DbSet<PessoaFisica> PessoaFisica { get; set; }
        
     public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}