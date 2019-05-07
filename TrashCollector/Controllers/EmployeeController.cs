using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            var pickUpsToday = DateTime.Now.DayOfWeek.ToString();
            ViewBag.DayOfWeek = pickUpsToday;
            //Natalie: ????Add drop down list to filter by other days here
            var currentUserId = User.Identity.GetUserId();
            var me = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
            var zoneCustomers = db.Customers.Where(c => c.ZipCode == me.ZipCode && c.PickUpDay == pickUpsToday);
            return View(zoneCustomers.ToList());

        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            //Natalie: Details on Cust profile, see address with pin using Google API
            //Natalie: ????ability to reference Cust table and confirm PU
            //Natalie:  ????Add button here to place charge on Customer's account after PU confirmation
            var currentUserId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
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
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
