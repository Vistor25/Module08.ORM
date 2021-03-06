﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFORM.Models
{
    [Table("Northwind.Regions")]
    public partial class Regions
    {
        public Regions()
        {
            Territories = new HashSet<Territory>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionsID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}