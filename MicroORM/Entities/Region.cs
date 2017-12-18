using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM.Entities
{
    [Table(Name = "Region")]
    public class Region
    {
        [PrimaryKey, Identity]
        [Column(Name = "RegionID")]
        public int RegionID { get; set; }

        [Column(Name = "RegionDescription"), NotNull]
        public string RegionDescription { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "RegionID", CanBeNull = false)]
        public IEnumerable<Territory> Territories { get; set; }
    }
}
