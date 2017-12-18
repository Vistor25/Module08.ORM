using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "CustomerCustomerDemo")]
    public class CustomerCustomerDemo
    {
        [PrimaryKey(1), NotNull]
        public string CustomerID { get; set; }

        [PrimaryKey(2), NotNull]
        public string CustomerTypeID { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = false)]
        public Customer Customer { get; set; }

        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", CanBeNull = false)]
        public CustomerDemographic CustomerDemographic { get; set; }
    }
}
