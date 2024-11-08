using EB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EB.Application.Services.CQS;

public interface IEntityDbSet
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
}
