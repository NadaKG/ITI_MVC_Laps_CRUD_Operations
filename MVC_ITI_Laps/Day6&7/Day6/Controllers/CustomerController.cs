using Day6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day6.Controllers
{

    public class CustomerController : Controller
    {

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public CustomerController(IWebHostEnvironment webHostEnvironment)  
        {
            WebHostEnvironment = webHostEnvironment;
        }


        CoContext db = new CoContext();
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.envName = WebHostEnvironment.EnvironmentName;
            ViewBag.AppName = WebHostEnvironment.ApplicationName;
            return View(db.Customers.Include(o=>o.Orders).ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Customers.Include(o => o.Orders).Where(c=>c.CustomerId == id).FirstOrDefault());
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else return View(cus);

            }
            catch
            {
                return View(cus);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Customers.Include(o => o.Orders).Where(c => c.CustomerId == id).FirstOrDefault());
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer cus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer editedcus = db.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
                    editedcus.CustomerId = cus.CustomerId;
                    editedcus.Email = cus.Email;
                    editedcus.Name = cus.Name;
                    editedcus.Phone = cus.Phone;
                    editedcus.gender = cus.gender;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else return View(cus);

            }
            catch
            {
                return View(cus);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Customers.Find(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer cus)
        {
            Customer deletedcus = db.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            if (cus != null)
            {
                db.Remove(deletedcus);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cus);
            }

        }
    }
}
