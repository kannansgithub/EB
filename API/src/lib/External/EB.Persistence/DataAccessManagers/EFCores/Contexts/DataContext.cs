using EB.Application.Services.CQS;
using EB.Domain.Entities;
using EB.Persistence.DataAccessManagers.EFCores.Configurations;
using EB.Persistence.Interceptors;
using EB.Persistence.SecurityManagers.AspNetIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EB.Persistence.DataAccessManagers.EFCores.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<ApplicationUser>(options), IEntityDbSet
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Color> Color { get; set; }
    public DbSet<Config> Config { get; set; }
    public DbSet<Counter> Counter { get; set; }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<FileDoc> FileDoc { get; set; }
    public DbSet<FileImage> FileImage { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<NumberSequence> NumberSequence { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<PurchaseItem> PurchaseItem { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
    public DbSet<PurchaseReturn> PurchaseReturn { get; set; }
    public DbSet<SaleItem> SaleItem { get; set; }
    public DbSet<SaleOrder> SaleOrder { get; set; }
    public DbSet<SaleReturn> SaleReturn { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    public DbSet<Tax> Tax { get; set; }
    public DbSet<Token> Token { get; set; }
    public DbSet<Uom> Uom { get; set; }
    public DbSet<Vendor> Vendor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new PerformanceInterceptor());
        optionsBuilder.AddInterceptors(new AuditingInterceptor());
    }

}
