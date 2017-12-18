using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Orders")]
    public class Order
    {
        [PrimaryKey, Identity]
        [Column(Name = "OrderID")]
        public int OrderID { get; set; }

        [Column(Name = "OrderDate")]
        public DateTime OrderDate { get; set; }

        [Column(Name = "RequiredDate")]
        public DateTime RequiredDate { get; set; }

        [Column(Name = "ShippedDate")]
        public DateTime ShippedDate { get; set; }

        [Column(Name = "Freight")]
        public int? Freight { get; set; }

        [Column(Name = "ShipName")]
        public string ShipName { get; set; }

        [Column(Name = "ShipAddress")]
        public string ShipAddress { get; set; }

        [Column(Name = "ShipCity")]
        public string ShipCity { get; set; }

        [Column(Name = "ShipRegion")]
        public string ShipRegion { get; set; }

        [Column(Name = "ShipPostalCode")]
        public string ShipPostalCode { get; set; }

        [Column(Name = "ShipCountry")]
        public string ShipCountry { get; set; }

        [Column(Name = "CustomerID")]
        public string CustomerID { get; set; } 

        [Column(Name = "EmployeeID")]
        public int? EmployeeID { get; set; }

        [Column(Name = "ShipVia")]
        public int? ShipVia { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = true)]
        public Customer Customer { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = true)]
        public Employee Employee { get; set; }

        [Association(ThisKey = "ShipVia", OtherKey = "ShipperID", CanBeNull = true)]
        public Shipper Shipper { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID", CanBeNull = false)]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
