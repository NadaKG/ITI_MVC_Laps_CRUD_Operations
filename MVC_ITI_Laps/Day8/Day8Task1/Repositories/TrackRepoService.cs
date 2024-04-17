using Day8Task1.Models;

namespace Day8Task1.Repositories
{
    public class TrackRepoService : ITrackRepository
    {
        public TraineeContext Context { get; set; }
        public TrackRepoService(TraineeContext context)
        {
            Context = context;
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetDetails(int id)
        {
            return Context.Tracks.Find(id);
        }

        public void Insert(Track track)
        {
            if (track != null)
            {
                Context.Tracks.Add(track);
                Context.SaveChanges();
            }
        }

        public void Update(int id, Track track)
        {
            Track updatedtrack = Context.Tracks.Find(id);
            if (updatedtrack != null)
            {
                updatedtrack.Description = track.Description;
                updatedtrack.Name = track.Name;
                updatedtrack.Trainees = track.Trainees;
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Track track = Context.Tracks.Find(id);
            if (track != null)
            {
                Context.Tracks.Remove(track);
                Context.SaveChanges();
            }
        }
    }
}
