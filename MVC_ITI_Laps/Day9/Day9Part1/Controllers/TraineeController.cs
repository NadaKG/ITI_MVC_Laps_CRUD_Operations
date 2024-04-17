using Day8Task1.Models;
using Day8Task1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day8Task1.Controllers
{
    //[Authorize]
    
    public class TraineeController : Controller
    {
        public ITraineeRepository Traineerepository { get; set; }
        public ITrackRepository TrackRepository { get; set; }
        public TraineeController(ITraineeRepository traineeRepository , ITrackRepository trackRepository)
        {
            Traineerepository = traineeRepository;
            TrackRepository = trackRepository;
        }
        // GET: TraineeController
        public ActionResult Index()
        {
            return View(Traineerepository.GetAll());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(Traineerepository.GetDetails(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.TrackID = new SelectList(TrackRepository.GetAll(), "TrackId", "Name");
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee)
        {
            ViewBag.TrackID = new SelectList(TrackRepository.GetAll(), "TrackId", "Name");
            if (ModelState.IsValid)
            try
            {
                Traineerepository.Insert(trainee);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception ex)
            {
                    ModelState.AddModelError("", ex.Message);
                 return View(trainee);
            }
            else
            return View(trainee);
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TrackID = new SelectList(TrackRepository.GetAll(), "TrackId", "Name");
            return View(Traineerepository.GetDetails(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee trainee)
        {
            ViewBag.TrackID = new SelectList(TrackRepository.GetAll(), "TrackId", "Name");
            if (ModelState.IsValid)
            {
                try
                {
                    Traineerepository.Update(id,trainee);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else return View(trainee);
        }

        // GET: TraineeController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var trainee = Traineerepository.GetDetails(id);
            if (trainee == null)
            {
                return NotFound(); 
            }
            return View(trainee);
        }

        // POST: TraineeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Traineerepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var trainee = Traineerepository.GetDetails(id);
                if (trainee == null)
                {
                   
                    return NotFound();
                }
                return View(trainee);
            }
            
        }
    }
}
