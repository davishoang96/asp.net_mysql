using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace asp.net_mysql_crud.Models
{
  public class DataContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json");
      var configuration = builder.Build();

            
      optionsBuilder.UseMySql(configuration["ConnectionString:DefaultConnection"]);
    }

    public DbSet<Product> Products {get;set;}
  }
}