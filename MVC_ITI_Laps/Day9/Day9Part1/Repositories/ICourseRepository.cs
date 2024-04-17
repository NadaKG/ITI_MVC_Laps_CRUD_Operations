using Day8Task1.Models;

namespace Day8Task1.Repositories
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetDetails(int id);
        public void Insert(Course course);
        public void Update(int id, Course course);
        public void Delete(int id);
    }
}
