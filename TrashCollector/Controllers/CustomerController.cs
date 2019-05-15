using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //ApplicationDbContext context;
        //public CustomerController()
        //{
        //    context = new ApplicationDbContext();
        //}

        // GET: Customer
        public ActionResult Index()
        {
            //Natalie:Easy way to see their bill and amount owed here
           
            var currentUserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == currentUserId);
            //var billing = db.Customers.Where(c => c.CustomerBill).FirstOrDefault();
            //var customerInfo = context.Include(context => context.ApplicationUser);
            //var customerInfo = db.Customers.ToList();
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            //Natalie:list of pickupday, extra pickup option, start and end date with option to edit
            var currentUserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == currentUserId).FirstOrDefault();
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var WeekDays = db.PickUpDays.ToList();
            Customer customer = new Customer()
            {
                PickUpDays = WeekDays
            };
            //Mike's snippet
            //ViewBag.PickUpDayId = new (db.PickUpDays, "PickUpDayId", "DayOfWeek");
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Street, City, State, ZipCode, PickUpDayId, CustomPickUp, PickUpStart, PickUpEnd, CustomerBill")] Customer customer)
        {

            try
            {
                var DayIs = db.PickUpDays.Where(p => p.Id == customer.PickUpDayId).FirstOrDefault();
                customer.PickUpDay = DayIs;
                //customer.DayOfWeek = DayIs.DayOfWeek;
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
                return RedirectToAction("Index", "Customer");
            }
            catch
            {
                return View("Index",customer);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {

                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
