using Day8Task1.Models;
using Day8Task1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day9.Controllers
{
    [Route("ManageTracks")]
    [Authorize]
    public class TrackController : Controller
    {
        public ITrackRepository Trackrepository { get; set; }
        public TrackController(ITrackRepository trackRepository)
        {
            Trackrepository = trackRepository;
        }
        // GET: TrackController
        [Route("Home")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(Trackrepository.GetAll());
        }

        // GET: TrackController/Details/5
        [Route("TrackDetails/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(Trackrepository.GetDetails(id));
        }

        // GET: TrackController/Create
        [Route("NewTrack")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackController/Create
        [HttpPost("NewTrack")]
        public ActionResult Create(Track track)
        {

            if (ModelState.IsValid)
                try
                {
                    Trackrepository.Insert(track);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(track);
                }
            else
                return View(track);
        }

        // GET: TrackController/Edit/5
        [Route("EditTrack/{id:int:range(1,20)}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Trackrepository.GetDetails(id));
        }

        // POST: TrackController/Edit/5
        [HttpPost("EditTrack/{id:int:range(1,20)}")]
        public ActionResult Edit(int id, Track track)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Trackrepository.Update(id, track);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(track);
                }
            }
            else return View(track);
        }

        // GET: TrackController/Delete/5
        [HttpGet]
        [Route("DeleteTrack/{id:int:range(1,20)}")]
        public ActionResult Delete(int id)
        {
            var track = Trackrepository.GetDetails(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: TrackController/Delete/5
        [HttpPost("DeleteTrack/{id:int:range(1,20)}"), ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Trackrepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var track = Trackrepository.GetDetails(id);
                if (track == null)
                {

                    return NotFound();
                }
                return View(track);
            }

        }
    }
}
