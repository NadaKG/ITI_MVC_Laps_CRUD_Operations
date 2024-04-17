using Day6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace Day6.Controllers
{
    public class OrderController : Controller
    {
        CoContext db = new CoContext();

        // GET: OrderController
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.allcus = new SelectList(db.Customers.ToList(), "CustomerId", "Name");
           
            return View(db.Orders.Include(c=>c.Customer).ToList());
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            int cusid = customer.CustomerId;
            var selectedcus = db.Orders.Include(o => o.Customer).Where(or => or.CustmrId == cusid).ToList();


            SelectList cusSelectList = new SelectList(db.Customers.ToList(), "CustomerId", "Name", cusid);
            ViewBag.allcus = cusSelectList;

            return View(selectedcus);
        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Orders.Include(c=>c.Customer).Where(o=> o.Orderid == id).FirstOrDefault());
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.CustmrId = db.Customers.ToList();

            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            ViewBag.CustmrId = db.Customers.ToList();
            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                    return View(order);
            }
            catch
            {
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CustmrId = db.Customers.ToList();

            return View(db.Orders.Include(o => o.Customer).Where(c => c.Orderid == id).FirstOrDefault());
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            ViewBag.CustmrId = db.Customers.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    Order neword = db.Orders.Where(o => o.Orderid == id).FirstOrDefault();
                    neword.Orderid = order.Orderid;
                    neword.TotalPrice = order.TotalPrice;
                    neword.Date = order.Date;
                    neword.CustmrId = order.CustmrId;
                    neword.Customer = order.Customer;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else return View(order);
            }
            catch
            {
                return View(order);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Orders.Find(id));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order order)
        {
            Order deletedorder = db.Orders.Where(e => e.Orderid == id).FirstOrDefault();
            if (order != null)
            {
                db.Remove(deletedorder);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(order);
            }
        }
    }
}
