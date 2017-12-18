using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Order Details")]
    public class OrderDetails
    {
        [PrimaryKey(1), NotNull]
        public int OrderID { get; set; }

        [PrimaryKey(2), NotNull]
        public int ProductID { get; set; }

        [Column(Name = "UnitPrice"), NotNull]
        public int UnitPrice { get; set; }

        [Column(Name = "Quantity"), NotNull]
        public int Quantity { get; set; }

        [Column(Name = "Discount"), NotNull]
        public double Discount { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID", CanBeNull = false)]
        public Order Order { get; set; }

        [Association(ThisKey = "ProductID", OtherKey = "ProductID", CanBeNull = false)]
        public Product Product { get; set; }
    }
}
