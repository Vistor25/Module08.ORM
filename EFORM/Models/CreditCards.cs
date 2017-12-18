using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFORM.Models
{
    [Table("Northwind.CreditCards")]
    public partial class CreditCards
    {
        public CreditCards()
        {
        }

        [Key]
        public int CreditCardID { get; set; }

        [Required]
        public int CardNumber { get; set; }

        [Required]
        public DateTime ExperationDate { get; set; }

        [Required]
        public string CardHolder { get; set; }

        public virtual Customer Customer { get; set; }
    }
}