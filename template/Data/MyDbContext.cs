using Microsoft.EntityFrameworkCore;
using template.Models;

namespace template.Data;

public class MyDbContext : DbContext
{
    public DbSet<AvailableProgram> AvailablePrograms { get; set; } = null!;
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<WashingProgram> WashingProgram { get; set; } = null!;
    public DbSet<WashingMachine> WashingMachines { get; set; } = null!;

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Martin",
                LastName = "Doe",
                PhoneNumber = "9876543210",
            }
        };

        var washingMachines = new List<WashingMachine>
        {
            new WashingMachine { WashingMachineId = 1, MaxWeight = 10m, SerialNumber = "SN1234567890" },
            new WashingMachine { WashingMachineId = 2, MaxWeight = 12m, SerialNumber = "SN1234567891" },
        };

        var programs = new List<WashingProgram>
        {
            new WashingProgram { ProgramId = 1, Name = "Quick Wash", DurationMinutes = 30, TemperatureCelsuis = 30 },
            new WashingProgram { ProgramId = 2, Name = "Heavy Duty", DurationMinutes = 60, TemperatureCelsuis = 30 }
        };

        var availablePrograms = new List<AvailableProgram>
        {
            new AvailableProgram
            {
                AvailableProgramId = 1,
                WashingMachineId = 1,
                ProgramId = 1,
                Price = 10.00m
            },
            new AvailableProgram
            {
                AvailableProgramId = 2,
                WashingMachineId = 1,
                ProgramId = 2,
                Price = 15.00m
            },
            new AvailableProgram
            {
                AvailableProgramId = 3,
                WashingMachineId = 2,
                ProgramId = 1,
                Price = 12.00m
            }
        };


        var purchaseHistories = new List<PurchaseHistory>
        {
            new PurchaseHistory
            {
                AvailableProgramId = 1,
                CustomerId = 1,
                PurchaseDate = new DateTime(2024, 01, 01, 10, 00, 00),
            },
            new PurchaseHistory
            {
                AvailableProgramId = 2,
                CustomerId = 1,
                PurchaseDate = new DateTime(2024, 01, 01, 10, 00, 00),
                Rating = 4
            }
        };
        
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<WashingMachine>().HasData(washingMachines);
        modelBuilder.Entity<WashingProgram>().HasData(programs);
        modelBuilder.Entity<AvailableProgram>().HasData(availablePrograms);
        modelBuilder.Entity<PurchaseHistory>().HasData(purchaseHistories);
    }
}