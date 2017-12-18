using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Shippers")]
    public class Shipper
    {
        [PrimaryKey, Identity]
        [Column(Name = "ShipperID")]
        public int ShipperID { get; set; }

        [Column(Name = "CompanyName"), NotNull]
        public string CompanyName { get; set; }

        [Column(Name = "Phone")]
        public string Phone { get; set; }

        [Association(ThisKey = "ShipperID", OtherKey = "ShipVia", CanBeNull = true)]
        public IEnumerable<Order> Orders { get; set; }
    }
}
