using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MicroORM.Entities
{
    [Table(Name = "Categories")]
    public class Category
    {
        [PrimaryKey, Identity]
        [Column(Name = "CategoryID")]
        public int CategoryID { get; set; }

        [Column(Name = "CategoryName"), NotNull]
        public string CategoryName { get; set; }

        [Column(Name = "Description")]
        public string Description { get; set; }

        [Column(Name = "Picture")]
        public byte[] Picture { get; set; }

        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID", CanBeNull = true)]
        public IEnumerable<Product> Products { get; set; }
    }
}
