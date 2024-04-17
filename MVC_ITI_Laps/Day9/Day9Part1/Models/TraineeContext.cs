using Day9.Models;
using Day9.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day8Task1.Models
{
    public class TraineeContext : IdentityDbContext<AppUser>
    {
        public TraineeContext(DbContextOptions<TraineeContext> options): base(options)
        {
            
        }

        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public DbSet<RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<Day9.Models.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;


    }
}
