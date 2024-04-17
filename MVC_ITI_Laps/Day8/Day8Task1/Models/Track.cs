using System.ComponentModel.DataAnnotations;

namespace Day8Task1.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual IEnumerable<Trainee>? Trainees{ get; set; }
    }
}
