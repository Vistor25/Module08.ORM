namespace EFPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Northwind.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 15),
                        Description = c.String(storeType: "ntext"),
                        Picture = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "Northwind.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 40),
                        SupplierID = c.Int(),
                        CategoryID = c.Int(),
                        QuantityPerUnit = c.String(maxLength: 20),
                        UnitPrice = c.Decimal(storeType: "money"),
                        UnitsInStock = c.Short(),
                        UnitsOnOrder = c.Short(),
                        ReorderLevel = c.Short(),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("Northwind.Categories", t => t.CategoryID)
                .ForeignKey("Northwind.Suppliers", t => t.SupplierID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "Northwind.Order Details",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("Northwind.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("Northwind.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Northwind.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(maxLength: 5),
                        EmployeeID = c.Int(),
                        OrderDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        ShipVia = c.Int(),
                        Freight = c.Decimal(storeType: "money"),
                        ShipName = c.String(maxLength: 40),
                        ShipAddress = c.String(maxLength: 60),
                        ShipCity = c.String(maxLength: 15),
                        ShipRegion = c.String(maxLength: 15),
                        ShipPostalCode = c.String(maxLength: 10),
                        ShipCountry = c.String(maxLength: 15),
                        Shipper_ShipperID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("Northwind.Customers", t => t.CustomerID)
                .ForeignKey("Northwind.Employees", t => t.EmployeeID)
                .ForeignKey("Northwind.Shippers", t => t.Shipper_ShipperID)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID)
                .Index(t => t.Shipper_ShipperID);
            
            CreateTable(
                "Northwind.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 5),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        FoundationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "Northwind.CustomerDemographics",
                c => new
                    {
                        CustomerTypeID = c.String(nullable: false, maxLength: 10),
                        CustomerDesc = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.CustomerTypeID);
            
            CreateTable(
                "Northwind.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        Title = c.String(maxLength: 30),
                        TitleOfCourtesy = c.String(maxLength: 25),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        HomePhone = c.String(maxLength: 24),
                        Extension = c.String(maxLength: 4),
                        Photo = c.Binary(storeType: "image"),
                        Notes = c.String(storeType: "ntext"),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(maxLength: 255),
                        Employee1_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("Northwind.Employees", t => t.Employee1_EmployeeID)
                .Index(t => t.Employee1_EmployeeID);
            
            CreateTable(
                "Northwind.Territories",
                c => new
                    {
                        TerritoryID = c.String(nullable: false, maxLength: 20),
                        TerritoryDescription = c.String(nullable: false, maxLength: 50),
                        RegionID = c.Int(nullable: false),
                        Region_RegionsID = c.Int(),
                    })
                .PrimaryKey(t => t.TerritoryID)
                .ForeignKey("Northwind.Regions", t => t.Region_RegionsID)
                .Index(t => t.Region_RegionsID);
            
            CreateTable(
                "Northwind.Regions",
                c => new
                    {
                        RegionsID = c.Int(nullable: false),
                        RegionDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RegionsID);
            
            CreateTable(
                "Northwind.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "Northwind.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        HomePage = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "Northwind.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ExperationDate = c.DateTime(nullable: false),
                        CardHolder = c.String(nullable: false),
                        Customer_CustomerID = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("Northwind.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.CustomerDemographicCustomers",
                c => new
                    {
                        CustomerDemographic_CustomerTypeID = c.String(nullable: false, maxLength: 10),
                        Customer_CustomerID = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => new { t.CustomerDemographic_CustomerTypeID, t.Customer_CustomerID })
                .ForeignKey("Northwind.CustomerDemographics", t => t.CustomerDemographic_CustomerTypeID, cascadeDelete: true)
                .ForeignKey("Northwind.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerDemographic_CustomerTypeID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.TerritoryEmployees",
                c => new
                    {
                        Territory_TerritoryID = c.String(nullable: false, maxLength: 20),
                        Employee_EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Territory_TerritoryID, t.Employee_EmployeeID })
                .ForeignKey("Northwind.Territories", t => t.Territory_TerritoryID, cascadeDelete: true)
                .ForeignKey("Northwind.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .Index(t => t.Territory_TerritoryID)
                .Index(t => t.Employee_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Northwind.CreditCards", "Customer_CustomerID", "Northwind.Customers");
            DropForeignKey("Northwind.Products", "SupplierID", "Northwind.Suppliers");
            DropForeignKey("Northwind.Order Details", "ProductID", "Northwind.Products");
            DropForeignKey("Northwind.Orders", "Shipper_ShipperID", "Northwind.Shippers");
            DropForeignKey("Northwind.Order Details", "OrderID", "Northwind.Orders");
            DropForeignKey("Northwind.Territories", "Region_RegionsID", "Northwind.Regions");
            DropForeignKey("dbo.TerritoryEmployees", "Employee_EmployeeID", "Northwind.Employees");
            DropForeignKey("dbo.TerritoryEmployees", "Territory_TerritoryID", "Northwind.Territories");
            DropForeignKey("Northwind.Orders", "EmployeeID", "Northwind.Employees");
            DropForeignKey("Northwind.Employees", "Employee1_EmployeeID", "Northwind.Employees");
            DropForeignKey("Northwind.Orders", "CustomerID", "Northwind.Customers");
            DropForeignKey("dbo.CustomerDemographicCustomers", "Customer_CustomerID", "Northwind.Customers");
            DropForeignKey("dbo.CustomerDemographicCustomers", "CustomerDemographic_CustomerTypeID", "Northwind.CustomerDemographics");
            DropForeignKey("Northwind.Products", "CategoryID", "Northwind.Categories");
            DropIndex("dbo.TerritoryEmployees", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.TerritoryEmployees", new[] { "Territory_TerritoryID" });
            DropIndex("dbo.CustomerDemographicCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.CustomerDemographicCustomers", new[] { "CustomerDemographic_CustomerTypeID" });
            DropIndex("Northwind.CreditCards", new[] { "Customer_CustomerID" });
            DropIndex("Northwind.Territories", new[] { "Region_RegionsID" });
            DropIndex("Northwind.Employees", new[] { "Employee1_EmployeeID" });
            DropIndex("Northwind.Orders", new[] { "Shipper_ShipperID" });
            DropIndex("Northwind.Orders", new[] { "EmployeeID" });
            DropIndex("Northwind.Orders", new[] { "CustomerID" });
            DropIndex("Northwind.Order Details", new[] { "ProductID" });
            DropIndex("Northwind.Order Details", new[] { "OrderID" });
            DropIndex("Northwind.Products", new[] { "CategoryID" });
            DropIndex("Northwind.Products", new[] { "SupplierID" });
            DropTable("dbo.TerritoryEmployees");
            DropTable("dbo.CustomerDemographicCustomers");
            DropTable("Northwind.CreditCards");
            DropTable("Northwind.Suppliers");
            DropTable("Northwind.Shippers");
            DropTable("Northwind.Regions");
            DropTable("Northwind.Territories");
            DropTable("Northwind.Employees");
            DropTable("Northwind.CustomerDemographics");
            DropTable("Northwind.Customers");
            DropTable("Northwind.Orders");
            DropTable("Northwind.Order Details");
            DropTable("Northwind.Products");
            DropTable("Northwind.Categories");
        }
    }
}
