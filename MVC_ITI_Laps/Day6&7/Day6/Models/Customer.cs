using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Day6.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        public IEnumerable<Order>? Orders { get; set; }

        public enum Gender { Male, Female }
    }
}
