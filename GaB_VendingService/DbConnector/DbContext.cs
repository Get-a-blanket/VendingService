using GaB_VendingService.DbConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace GaB_VendingService.DbConnector;

public class ApplicationContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //настройка связей модели базы данных 
        modelBuilder.Entity<Cell>()
            .HasOne(c => c.CellStatus)
            .WithMany()
            .HasForeignKey(c => c.CellStatusId)
            .HasPrincipalKey(cs => cs.Id);

        modelBuilder.Entity<VendingMachine>()
            .HasMany(vm => vm.Cells)
            .WithOne(c => c.VendingMachine)
            .HasForeignKey(c => c.VendingMachineId)
            .HasPrincipalKey(vm => vm.Id);

        modelBuilder.Entity<VendingMachine>()
            .HasMany(vm => vm.Connections)
            .WithOne(c => c.VendingMachine)
            .HasForeignKey(c => c.VendingMachineId)
            .HasPrincipalKey(vm => vm.Id);

        // заполнять типы если они не заполнены https://metanit.com/sharp/efcore/2.14.php

        //Заполнение типов статусов
        modelBuilder.Entity<CellStatus>().HasData(
            new CellStatus { Id = 1, Name = "Empty" },
            new CellStatus { Id = 2, Name = "Clean" },
            new CellStatus { Id = 3, Name = "Dirty" }
        );

        //тестовые данные
        if (WebApplication.CreateBuilder().Build().Environment.IsDevelopment()) //TODO проверить создает ли на prod
        {
            //пример
            //modelBuilder.Entity<Client>().HasData(
            //    new Client
            //    {
            //        Id = Guid.Parse("fa2e2a6f-6703-4ef0-8765-941d20d10a70"),
            //        DateOfRegistration = DateTime.UtcNow,
            //        Email = "info@getablanket.ru",
            //        PhoneRegionCodeId = russianRegionCode.Id,
            //        PhoneNumber = 1234567890,
            //        ActiveBlankets = []
            //    }
            //);
        }

    }
}