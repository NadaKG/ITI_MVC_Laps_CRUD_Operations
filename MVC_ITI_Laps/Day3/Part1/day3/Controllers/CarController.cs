using day3.Models;
using Microsoft.AspNetCore.Mvc;

namespace day3.Controllers
{
    public class CarController : Controller
    {
        public IActionResult GetAll()
        {
            ViewBag.allcars = CarList.Cars.ToList();
            return View();
        }

        public IActionResult GetByNum(int number)
        {
            ViewBag.car = CarList.Cars.Where(n => n.Number == number).FirstOrDefault();
            return View();
        }

        public IActionResult Edit(int number)
        {
            ViewBag.car = CarList.Cars.Where(n => n.Number == number).FirstOrDefault();
            return View();
        }

        public IActionResult EditSave(Car car)
        {
            var newcar = CarList.Cars.Where(n => n.Number == car.Number).FirstOrDefault();
            newcar.Color = car.Color;
            newcar.Model = car.Model;
            newcar.Manufacturer = car.Manufacturer;

            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int number)
        {
            var car = CarList.Cars.Where(n => n.Number == number).FirstOrDefault();
            if(car != null)
            {
                CarList.Cars.Remove(car);
            }
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(int number , string color , string model, string manufacturer)
        {
            var car = new Car()
            {
                Number = number,
                Color = color,
                Manufacturer = manufacturer,
                Model = model
            };

            CarList.Cars.Add(car);
            return RedirectToAction("GetAll");
        }
    }
}
