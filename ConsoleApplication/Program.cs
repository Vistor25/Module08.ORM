using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MicroORM;
using LinqToDB;
using MicroORM.Entities;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetListOfProductsWithProperties();
            GetListOfEmployeesWithRegion();
            StatisticsOfRegions();
            AddNewEmployeeWithListOfTerritories();
            UpdateProductCategory(1, 2);
            InsertProductsWithCategoryAndSupplier();
            ReplaceProduct();
            Console.ReadKey();
        }

        static void GetListOfProductsWithProperties()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            foreach (var product in db.Products.LoadWith(t => t.Category).LoadWith(t => t.Supplier))
            {
                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.Category?.CategoryName);
                Console.WriteLine(product.Supplier?.CompanyName);
                Console.WriteLine("---------------------------------------------------");
            }
        }

        static void GetListOfEmployeesWithRegion()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            var employeesWithRegions = db.Employees.Join(db.EmployeeTerritories.Join(db.Territories.LoadWith(x => x.Region),
                leftItem => leftItem.TerritoryID,
                rightItem => rightItem.TerritoryID,
                (leftItem, rightItem) => new
                {
                    leftItem.EmployeeID,
                    rightItem.Region.RegionDescription
                }),
                leftItem => leftItem.EmployeeID,
                rightItem => rightItem.EmployeeID,
                (leftItem, rightItem) => new
                {
                    EmployeeID = leftItem.LastName,
                    Region = rightItem.RegionDescription
                }).Distinct().GroupBy(x => x.EmployeeID);

            foreach (var employee in employeesWithRegions)
            {
                Console.WriteLine($"Employee lastname - {employee.Key}");
                foreach (var region in employee)
                {
                    Console.WriteLine($"Region - {region.Region}");
                }
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void StatisticsOfRegions()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            var Regions = db.Employees.Join(db.EmployeeTerritories.Join(db.Territories.LoadWith(x => x.Region),
                leftItem => leftItem.TerritoryID,
                rightItem => rightItem.TerritoryID,
                (leftItem, rightItem) => new
                {
                    leftItem.EmployeeID,
                    rightItem.Region.RegionDescription
                }),
                leftItem => leftItem.EmployeeID,
                rightItem => rightItem.EmployeeID,
                (leftItem, rightItem) => new
                {
                    EmployeeID = leftItem.LastName,
                    Region = rightItem.RegionDescription
                }).Distinct().GroupBy(key => key.Region,
                            (myKey, collection) => new
                            {
                                Region = myKey,
                                Count = collection.Count()
                            });
            foreach (var region in Regions)
            {
                Console.WriteLine(region.Region);
                Console.WriteLine(region.Count);
            }
        }
        static void GetListEmployeesWithSupplier()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            var employeesWithListSuppliers = db.Orders.LoadWith(x => x.Employee).LoadWith(x => x.Shipper).Select(x => new { Employee = x.Employee.LastName, Shipper = x.Shipper.CompanyName })
                .Distinct().GroupBy(x => x.Employee);

            foreach (var employee in employeesWithListSuppliers)
            {
                Console.WriteLine($" Employee - {employee.Key}");
                foreach (var supplier in employee)
                {
                    Console.WriteLine(supplier.Shipper);
                }
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void AddNewEmployeeWithListOfTerritories()
        {
            DBNorthwind db = new DBNorthwind("Northwind");
            db.Insert(new EmployeeTerritory()
            {
                EmployeeID =Convert.ToInt32( db.InsertWithIdentity(new Employee()
                {
                    Region = "WA",
                    FirstName = "Andrew",
                    LastName = "Ivanov"
                })),
                TerritoryID = "03049"

            });
        }

        static void UpdateProductCategory(int oldValue, int newValue)
        {
            DBNorthwind db = new DBNorthwind("Northwind");
            db.Products.Where(x => x.CategoryID == oldValue).Set(y => y.CategoryID, newValue).Update();
        }
        static void InsertProductsWithCategoryAndSupplier()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            var listProduct = new List<Product>()
            {
                new Product()
                {
                    ProductName = "Prod 1",
                    Category = new Category
                    {
                        CategoryName = "Categ number 1"
                    },
                    Supplier = new Supplier
                    {
                        CompanyName = "Sup number 1"
                    }
                },

                new Product()
                {
                    ProductName = "Prod 2",
                    Category = new Category
                    {
                        CategoryName = "Categ number 2"
                    },
                    Supplier = new Supplier
                    {
                        CompanyName = "Sup number 2"
                    }
                }
            };

            foreach (var product in listProduct)
            {
                if (db.Categories.FirstOrDefault(y => y.CategoryName == product.Category.CategoryName) == null)
                {
                    db.InsertWithIdentity(new Category { CategoryName = product.Category.CategoryName });
                }
                if (db.Suppliers.FirstOrDefault(x => x.CompanyName == product.Supplier.CompanyName) == null)
                {
                    db.InsertWithIdentity(new Supplier { CompanyName = product.Supplier.CompanyName });
                }
                product.CategoryID = db.Categories.FirstOrDefault(x => x.CategoryName == product.Category.CategoryName).CategoryID;
                product.SupplierID = db.Suppliers.FirstOrDefault(x => x.CompanyName == product.Supplier.CompanyName).SupplierID;

                db.InsertWithIdentity(new Product
                {
                    ProductName = product.ProductName,
                    CategoryID = product.CategoryID,
                    SupplierID = product.SupplierID
                });
            }
        }

        static void ReplaceProduct()
        {
            DBNorthwind db = new DBNorthwind("Northwind");

            foreach (var order in db.Orders.Where(x => x.ShippedDate == null))
            {
                foreach (var ordInfo in db.OrderDetails.Where(x => x.OrderID == order.OrderID))
                {
                    int categoryId = (int)db.Products.FirstOrDefault(x => x.ProductID == ordInfo.ProductID).CategoryID;
                    Product prod = db.Products.FirstOrDefault(x => x.CategoryID == categoryId && x.ProductID != ordInfo.ProductID);
                    if (prod != null)
                    {
                        ordInfo.ProductID = prod.ProductID;
                    }
                }
            }
        }
    }
}
