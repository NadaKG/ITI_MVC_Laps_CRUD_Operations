using day2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace day2.Controllers
{
    public class IphonesController : Controller
    {
        public IActionResult ShowProductDetails(string name, string picture, double price, string description)
        {
            ViewData["name"] = name;
            ViewData["picture"] = picture;
            ViewData["description"] = description;
            ViewData["price"] = price;

            return View();
        }
        //Iphones/ShowProductDetails?name=iphone&picture=/Images/phone1.jpg&price=58000&description=%27Latest%20Iphone%27Pro%27Max%27Edition
    }
}
