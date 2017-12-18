using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Suppliers")]
    public class Supplier
    {
        [PrimaryKey, Identity]
        [Column(Name = "SupplierID")]
        public int SupplierID { get; set; }

        [Column(Name = "CompanyName"), NotNull]
        public string CompanyName { get; set; }

        [Column(Name = "ContactTitle")]
        public string ContactTitle { get; set; }

        [Column(Name = "Address")]
        public string Address { get; set; }

        [Column(Name = "City")]
        public string City { get; set; }

        [Column(Name = "Region")]
        public string Region { get; set; }

        [Column(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Column(Name = "Country")]
        public string Country { get; set; }

        [Column(Name = "Phone")]
        public string Phone { get; set; }

        [Column(Name = "Fax")]
        public string Fax { get; set; }

        [Column(Name = "HomePage")]
        public string HomePage { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", CanBeNull = true)]
        public IEnumerable<Product> Products { get; set; }
    }
}
