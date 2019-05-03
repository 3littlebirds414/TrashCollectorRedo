using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using Microsoft.AspNet.Identity;


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
        public ActionResult Index(int id)
        {
            //Natalie:Easy way to see their bill and amount owed here
            var currentUserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == currentUserId).FirstOrDefault();
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
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole");
            //Customer customer = new Customer();
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id,FirstName,LastName,Street,City,State,ZipCode,PickUpDay,PickUpComplete,CustomPickUp,PickUpStart,PicUpEnd")]Customer customer)
        {
            try
            {
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
