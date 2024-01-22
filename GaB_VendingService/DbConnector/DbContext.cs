using GaB_VendingService.DbConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace GaB_VendingService.DbConnector;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GaB_VendingService.ConfigurationManager.ConnectionStringProtectedDb);
    }
}