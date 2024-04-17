using Day8Task1.Models;
using Day8Task1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day8Task1.Controllers
{
    public class CourseController : Controller
    {
        public ICourseRepository Courserepository { get; set; }
        public CourseController(ICourseRepository courseRepository)
        {
            Courserepository = courseRepository;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View(Courserepository.GetAll());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(Courserepository.GetDetails(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            
            if (ModelState.IsValid)
                try
                {
                    Courserepository.Insert(course);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(course);
                }
            else
                return View(course);
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Courserepository.GetDetails(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Courserepository.Update(id, course);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(course);
                }
            }
            else return View(course);
        }

        // GET: CourseController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var course = Courserepository.GetDetails(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Courserepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var course = Courserepository.GetDetails(id);
                if (course == null)
                {

                    return NotFound();
                }
                return View(course);
            }

        }
    }
}
