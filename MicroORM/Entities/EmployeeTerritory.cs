using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [PrimaryKey(1), NotNull]
        [Column(Name = "EmployeeID")]
        public int EmployeeID { get; set; }

        [PrimaryKey(2), NotNull]
        [Column(Name = "TerritoryID")]
        public string TerritoryID { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = false)]
        public Employee Employee { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", CanBeNull = false)]
        public Territory Territory { get; set; }
    }
}
