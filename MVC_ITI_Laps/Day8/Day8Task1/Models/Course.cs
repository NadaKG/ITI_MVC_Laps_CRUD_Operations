using System.ComponentModel.DataAnnotations;

namespace Day8Task1.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Topic { get; set; }
        public float Grade { get; set; }
        public ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();

    }
}
