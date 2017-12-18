using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Employees")]
    public class Employee
    {
        [PrimaryKey, Identity]
        [Column(Name = "EmployeeID")]
        public int EmployeeID { get; set; }

        [Column(Name = "LastName"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "FirstName"), NotNull]
        public string FirstName { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        [Column(Name = "TitleOfCourtesy")]
        public string TitleOfCourtesy { get; set; }

        [Column(Name = "BirthDate")]
        public DateTime? BirthDate { get; set; }

        [Column(Name = "HireDate")]
        public DateTime? HireDate { get; set; }

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

        [Column(Name = "HomePhone")]
        public string HomePhone { get; set; }

        [Column(Name = "Extension")]
        public string Extension { get; set; }

        [Column(Name = "Photo")]
        public byte[] Photo { get; set; }

        [Column(Name = "Notes")]
        public string Notes { get; set; }

        [Column(Name = "PhotoPath")]
        public string PhotoPath { get; set; }

        [Column(Name = "ReportsTo")]
        public int? ReportsTo { get; set; }

        [Association(ThisKey = "ReportsTo", OtherKey = "EmployeeID", CanBeNull = true)]
        public Employee ThisEmployee { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "ReportsTo", CanBeNull = true)]
        public IEnumerable<Employee> Employees { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = true)]
        public IEnumerable<Order> Orders { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = false)]
        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
