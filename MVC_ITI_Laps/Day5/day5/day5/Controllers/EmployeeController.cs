using day5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace day5.Controllers
{
    public class EmployeeController : Controller
    {
        dbContext db = new dbContext();

        // GET: EmployeeController
        [HttpGet]
        public ActionResult Index()
        {
            SelectList deps = new SelectList(db.Department.ToList(), "Id", "Name");
            ViewBag.alldeps = deps;
            return View(db.Employee.Include(d=>d.Department).ToList());
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            int deptid = int.Parse(collection["Department_"]);
            var selectedemps = db.Employee.Include(d => d.Department).Where(dep => dep.DID == deptid).ToList();

            SelectList depSelectList = new SelectList(db.Department.ToList(), "Id", "Name", deptid);
            ViewBag.alldeps = depSelectList;

            return View(selectedemps);
        }
        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Employee.Include(d=>d.Department).Where(e=> e.ID == id).FirstOrDefault());
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.DID = new SelectList(db.Department.ToList(), "Id", "Name");
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if(emp != null)
            {
                db.Employee.Add(emp);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(emp);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DID = new SelectList(db.Department.ToList(), "Id", "Name");
            return View(db.Employee.Include(d=>d.Department).Where(e => e.ID == id).FirstOrDefault());
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
           if(emp != null)
            {
               Employee editedemp = db.Employee.Where(e=>e.ID == id).FirstOrDefault();
                editedemp.ID = emp.ID;
                editedemp.Name = emp.Name;
                editedemp.Salary = emp.Salary;
                editedemp.Email = emp.Email;
                editedemp.Password = emp.Password;
                editedemp.Phone = emp.Phone;
                editedemp.JoinDate = emp.JoinDate;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           else
            {
                return View(emp);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Employee.Include(d => d.Department).Where(e => e.ID == id).FirstOrDefault());
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee emp)
        {
            Employee deletemp = db.Employee.Where(e => e.ID == id).FirstOrDefault();
            if(emp != null)
            {
                db.Remove(deletemp);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(emp);
            }

        }
    }
}
