using Day8Task2.Models;
using Day8Task2.Repositories;
using Day8Task2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day8Task2.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerRepository Customerrepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public CustomerController(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            Customerrepository = customerRepository;
            ProductRepository = productRepository;
        }
        public ActionResult Index()
        {
            return View(Customerrepository.GetAll());
        }

        ///Customer/getCustomerOrdersDetails/1
        public IActionResult getCustomerOrdersDetails(int id)
        {
            Customer cus = Customerrepository.GetDetails(id);
            List<Product> prod = ProductRepository.GetAll();
            Product_Cust_ViewModel vmodel = new Product_Cust_ViewModel()
            {
                CustomerId = cus.CustomerId,
                CustomerName = cus.Name,
                Products = prod
            };
            return View(vmodel);
        }


        public ActionResult Details(int id)
        {
            return View(Customerrepository.GetDetails(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
                try
                {
                    Customerrepository.Insert(customer);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(customer);
                }
            else
                return View(customer);
        }

        public ActionResult Edit(int id)
        {
            return View(Customerrepository.GetDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customerrepository.Update(id, customer);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = Customerrepository.GetDetails(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Customerrepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var customer = Customerrepository.GetDetails(id);
                if (customer == null)
                {

                    return NotFound();
                }
                return View(customer);
            }
        }
    }
}
