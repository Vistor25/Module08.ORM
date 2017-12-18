using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Territories")]
    public class Territory
    {
        [PrimaryKey]
        [Column(Name = "TerritoryID")]
        public string TerritoryID { get; set; }

        [Column(Name = "TerritoryDescription"), NotNull]
        public string TerritoryDescription { get; set; }

        [Column(Name = "RegionID"), NotNull]
        public int RegionID { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "RegionID", CanBeNull = false)]
        public Region Region { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", CanBeNull = false)]
        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
