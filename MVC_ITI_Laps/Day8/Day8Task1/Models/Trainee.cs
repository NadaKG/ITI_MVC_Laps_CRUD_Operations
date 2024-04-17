using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Day8Task1.Models
{
    public class Trainee
    {
        [Key]
        public int TraineeId { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="Max Length is 20 characters")]
        public string Name { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [ForeignKey("Trk")]
        public int TrackID { get; set; }
        public Track? Trk { get; set; }
        public ICollection<Course>? Courses { get; set; } = new List<Course>();

        public enum Gender { Male, Female}
    }
}
