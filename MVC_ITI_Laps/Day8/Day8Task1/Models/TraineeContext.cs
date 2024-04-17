using Microsoft.EntityFrameworkCore;

namespace Day8Task1.Models
{
    public class TraineeContext : DbContext
    {
        public TraineeContext(DbContextOptions<TraineeContext> options): base(options)
        {
            
        }

        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

    }
}
