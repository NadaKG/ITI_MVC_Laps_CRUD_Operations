using System.ComponentModel.DataAnnotations.Schema;

namespace day5.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public int Salary { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        [ForeignKey("Department")]
        public int DID { get; set; }
        public virtual Department? Department { get; set; }

    }
}
