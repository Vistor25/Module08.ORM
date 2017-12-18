using System;
using LinqToDB.Mapping;
using System.Configuration;
using System.Collections.Generic;

namespace MicroORM.Entities
{
    [Table(Name = "Customers")]
    public class Customer
    {
        [PrimaryKey]
        [Column(Name = "CustomerID")]
        public string CustomerID { get; set; }

        [Column(Name = "CompanyName"), NotNull]
        public string CompanyName { get; set; }

        [Column(Name = "ContactName")]
        public string ContactName { get; set; }

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

        [Column(Name = "Date created")]
        public string DateCreated { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = true)]
        public IEnumerable<Order> Orders { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = false)]
        public IEnumerable<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    }
}
