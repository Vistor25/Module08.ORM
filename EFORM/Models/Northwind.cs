using System.Data.Entity;

namespace EFORM.Models
{
    public partial class Northwind : DbContext
    {
        public Northwind() : base("Northwind")
        {
            Database.SetInitializer<Northwind>(new CreateDatabaseIfNotExists<Northwind>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<
            //    Northwind, Migrations.Configuration>("Northwind"));
        }

        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
    }
}