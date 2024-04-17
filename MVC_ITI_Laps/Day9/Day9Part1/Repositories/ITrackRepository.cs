using Day8Task1.Models;

namespace Day8Task1.Repositories
{
    public interface ITrackRepository
    {
        public List<Track> GetAll();
        public Track GetDetails(int id);
        public void Insert(Track track);
        public void Update(int id, Track track);
        public void Delete(int id);
    }
}
