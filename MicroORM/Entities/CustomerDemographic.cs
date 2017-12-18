using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "CustomerDemographics")]
    public class CustomerDemographic
    {
        [PrimaryKey]
        [Column(Name = "CustomerTypeID")]
        public string CustomerTypeID { get; set; }

        [Column(Name = "CustomerDesc")]
        public string CustomerDesc { get; set; }

        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", CanBeNull = false)]
        public IEnumerable<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    }
}
