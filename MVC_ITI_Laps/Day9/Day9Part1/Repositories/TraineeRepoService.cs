using Day8Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day8Task1.Repositories
{
    public class TraineeRepoService : ITraineeRepository
    {
        public TraineeContext Context { get; set; }
        public TraineeRepoService(TraineeContext context)
        {
            Context = context;
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.Include(c=>c.Courses).Include(t=>t.Trk).ToList();
        }

        public Trainee GetDetails(int id)
        {
            return Context.Trainees.Include(t => t.Trk).FirstOrDefault(i => i.TraineeId == id);
        }

        public void Insert(Trainee trainee)
        {
            if (trainee != null)
            {
                Context.Trainees.Add(trainee);
                Context.SaveChanges();
            }
        }

        public void Update(int id, Trainee updatedValues)
        {
            Trainee traineeToUpdate = Context.Trainees.Include(t => t.Courses) .FirstOrDefault(t => t.TraineeId == id);

            if (traineeToUpdate != null)
            {
                
                traineeToUpdate.Name = updatedValues.Name;
                traineeToUpdate.Email = updatedValues.Email;
                traineeToUpdate.Birthdate = updatedValues.Birthdate;
                traineeToUpdate.gender = updatedValues.gender;
                traineeToUpdate.MobileNo = updatedValues.MobileNo;
                traineeToUpdate.TrackID = updatedValues.TrackID;
                Context.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            Trainee traineeToDelete = Context.Trainees.Find(id);
            if (traineeToDelete != null)
            {
                Context.Trainees.Remove(traineeToDelete);
                Context.SaveChanges();
            }
        }

    }
}

