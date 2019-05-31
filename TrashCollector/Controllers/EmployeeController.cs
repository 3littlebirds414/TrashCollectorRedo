using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index(string searchString)
        {

            if(searchString == null)
            {

                var pickUpsToday = DateTime.Now.DayOfWeek.ToString();
                ViewBag.DayOfWeek = pickUpsToday;
                //Natalie: ????Add drop down list to filter by other days here
                var currentUserId = User.Identity.GetUserId();
                var me = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
                var zoneCustomers = db.Customers.Where(c => c.ZipCode == me.ZipCode && c.PickUpDay.DayOfWeek == pickUpsToday).Include(c => c.PickUpDay).ToList();
                //foreach(Customer customer in zoneCustomers)
                //{
                //    customer.PickUpDay = db.PickUpDays.Where(pud => pud.Id == customer.PickUpDayId).FirstOrDefault();
                //}
                return View(zoneCustomers);
            }
            else
            {
                
                var currentUserId = User.Identity.GetUserId();
                var me = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
                var zoneCustomers = db.Customers.Where(c => c.ZipCode == me.ZipCode && c.PickUpDay.DayOfWeek == searchString).Include(c => c.PickUpDay).ToList();
              
                return View(zoneCustomers);

            }
        }

        public ActionResult CustomersByDay(string dayOfWeek)
        {
            var WeekDays = db.PickUpDays.ToList();

            ViewBag.DaysOfTheWeek = new SelectList(db.PickUpDays, "Id", "DayOfWeek");
            //Natalie: ????Add drop down list to filter by other days here
            //var currentUserId = User.Identity.GetUserId();
            //var me = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
            //var zoneDayCustomers = db.Customers.Where(c => c.ZipCode == me.ZipCode && c.PickUpDay.DayOfWeek == pickUpsOnThisDay).ToList();
            // remember to return the "Index" view
            return View("Index");
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? Id)
        {


            //Natalie: Details on Cust profile, see address with pin using Google API
            //Natalie: ????ability to reference Cust table and confirm PU
            //Natalie:  ????Add button here to place charge on Customer's account after PU confirmation
            var currentUserId = User.Identity.GetUserId();
            var me = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
            var myCustomers = db.Customers.Where(z => z.ZipCode==me.ZipCode).Include(c => c.PickUpDay).ToList();
          
            // var ListOnThisDay = db.Customers.Where(p => p.PickUpDay == me.ThisDay).ToList();
            return View(myCustomers);
        }


        // GET: Employee/Create
        public ActionResult Create()
        {

            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, ZipCode")]Employee employee)
        {
            try
            {
                // get current user Id
                //attach that to the employee
                var currentUserId = User.Identity.GetUserId();
                employee.ApplicationUserId = currentUserId;
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.PickUpDayId = new SelectList(db.PickUpDays, "PickUpDayId", "DayOfWeek");
            var thing = db.Customers.Where(s => s.Id == id).Include(r => r.PickUpDay).FirstOrDefault();
            thing.PickUpDays = db.PickUpDays.ToList();
            return View(thing);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: Employee/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Customer customer = db.Customers.Find(id);
            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            return View(customer);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
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

        //public ActionResult Map1(int? id)
        //{
        //    ViewBag.Key = Keys.GOOGLE_MAP_KEY;

        //    return View();
        //}
        
        public ActionResult UpdateBill(int id)
        {
            Customer customer = db.Customers.Find(id);
            //customer.CustomerBill += 10;
            
            //return RedirectToAction("Index");
            customer.CustomerBill += 10;
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View (customer);
        }

        public ActionResult Map(int? id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }
    }
}
