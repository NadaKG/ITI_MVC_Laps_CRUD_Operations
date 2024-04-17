using Day8Task2.Models;
using Day8Task2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day8Task2.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository Productrepository { get; set; }
        public ICustomerRepository Customerrepository { get; set; }

        public ProductController(IProductRepository productRepository , ICustomerRepository customerRepository)
        {
            Productrepository = productRepository;
            Customerrepository = customerRepository;
        }
        
        public ActionResult Index()
        {
            return View(Productrepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(Productrepository.GetDetails(id));
        }

        public ActionResult Create()
        {
           ViewBag.CustId = new SelectList(Customerrepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
                try
                {
                    Productrepository.Insert(product);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(product);
                }
            else
                return View(product);
        }

        public ActionResult Edit(int id)
        {
            return View(Productrepository.GetDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Productrepository.Update(id, product);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(product);
                }
            }
            else return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = Productrepository.GetDetails(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Productrepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var product = Productrepository.GetDetails(id);
                if (product == null)
                {

                    return NotFound();
                }
                return View(product);
            }

        }
    }
}
