using Day8Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day8Task1.Repositories
{
    public class CourseRepoService : ICourseRepository
    {
        public TraineeContext Context { get; set; }
        public CourseRepoService(TraineeContext context)
        {
            Context = context;
        }

        public List<Course> GetAll()
        {
            return Context.Courses.Include(c => c.Trainees).ToList();
        }

        public Course GetDetails(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Insert(Course course)
        {
            if (course != null)
            {
                Context.Courses.Add(course);
                Context.SaveChanges();
            }
        }

        public void Update(int id, Course course)
        {
            Course traineeToUpdate = Context.Courses.Find(id);

            if (traineeToUpdate != null)
            {
                traineeToUpdate.Topic = course.Topic;
                traineeToUpdate.Grade = course.Grade;
                traineeToUpdate.Trainees = course.Trainees;
                Context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Course courseToDelete = Context.Courses.Find(id);
            if (courseToDelete != null)
            {
                Context.Courses.Remove(courseToDelete);
                Context.SaveChanges();
            }
        }
    }
}
