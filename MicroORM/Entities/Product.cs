using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Products")]
    public class Product
    {
        [PrimaryKey, Identity]
        [Column(Name = "ProductID")]
        public int ProductID { get; set; }

        [Column(Name = "ProductName"), NotNull]
        public string ProductName { get; set; }

        [Column(Name = "QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column(Name = "UnitPrice")]
        public int? UnitPrice { get; set; }

        [Column(Name = "UnitsInStock")]
        public int? UnitsInStock { get; set; }

        [Column(Name = "UnitsOnOrder")]
        public int? UnitsOnOrder { get; set; }

        [Column(Name = "ReorderLevel")]
        public int? ReorderLevel { get; set; }

        [Column(Name = "Discontinued"), NotNull]
        public bool Discontinued { get; set; }

        [Column(Name = "SupplierID")]
        public int? SupplierID { get; set; }

        [Column(Name = "CategoryID")]
        public int? CategoryID { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", CanBeNull = true)]
        public Supplier Supplier { get; set; }

        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID", CanBeNull = true)]
        public Category Category { get; set; }

        [Association(ThisKey = "ProductID", OtherKey = "ProductID", CanBeNull = false)]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
