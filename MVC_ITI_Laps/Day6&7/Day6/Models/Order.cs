using Day6.Custom_Annotation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Orderid { get; set; }
        [Required]
        [NoPastDate]
        public DateOnly Date { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [ForeignKey("Customer")]
        [Required]
        [DisplayName("Customer")]
        public int CustmrId { get; set; }
        public Customer? Customer { get; set; }
    }
}
