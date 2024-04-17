using System.Collections.Generic;

namespace Day8Task2.Models
{
    public class Customer
    {
        public enum Gender { Male, Female }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public Gender gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
