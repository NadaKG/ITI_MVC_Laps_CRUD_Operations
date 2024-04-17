using System.ComponentModel.DataAnnotations.Schema;

namespace Day8Task2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set;}
        public int Price { get; set; }
        [ForeignKey("Customer")]

        public int CustId { get; set; }
        public Customer? Customer { get; set;}
    }
}
