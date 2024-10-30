using EB.Domain.Entities;
using EB.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EB.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
    {

    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Counter> Counters { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<SaleOrder> SaleOrders { get; set; }
    public DbSet<SaleReturn> SaleReturns { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Uom> Uoms { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new PerformanceInterceptor());
        optionsBuilder.AddInterceptors(new AuditingInterceptor());
    }
}
