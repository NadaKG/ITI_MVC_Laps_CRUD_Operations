using Day8Task1.Models;

namespace Day8Task1.Repositories
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();
        public Trainee GetDetails(int id);
        public void Insert(Trainee trainee);
        public void Update(int id , Trainee trainee);
        public void Delete(int id);

    }
}
