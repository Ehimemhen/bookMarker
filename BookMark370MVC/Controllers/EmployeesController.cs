using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMark370MVC.Models;

namespace BookMark370MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        // GET: Employees

        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                return View(db.Employees.Where(x => x.Employee_Name.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Email")
            {
                return View(db.Employees.Where(x => x.Emp_Email.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "Surname")
            {
                return View(db.Employees.Where(x => x.Employee_Surname.Equals(search) || search == null).ToList());
            }
            else if (searchBy == "Phone")
            {
                return View(db.Employees.Where(x => x.Emp_Phone.Value.ToString() == search || search == null).ToList());
            }
            else
            {
                return View(db.Employees.Where(x => x.Emp_Phone.Value.ToString() == search || search == null).ToList());
            }


        }
        //public ActionResult Index()
        //{
        //    var employees = db.Employees.Include(e => e.Employee_Gender).Include(e => e.Employee_Title).Include(e => e.User);
        //    return View(employees.ToList());
        //}

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmpGender_ID = new SelectList(db.Employee_Gender, "EmpGender_ID", "Gender_Description");
            ViewBag.EmpTitle_ID = new SelectList(db.Employee_Title, "EmpTitle_ID", "Title_Description");
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "UserName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,User_ID,Employee_Name,Employee_Surname,Employee_Address,Emp_Phone,Emp_Email,ID_Number,EmpTitle_ID,EmpGender_ID,ImageData")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpGender_ID = new SelectList(db.Employee_Gender, "EmpGender_ID", "Gender_Description", employee.EmpGender_ID);
            ViewBag.EmpTitle_ID = new SelectList(db.Employee_Title, "EmpTitle_ID", "Title_Description", employee.EmpTitle_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "UserName", employee.User_ID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpGender_ID = new SelectList(db.Employee_Gender, "EmpGender_ID", "Gender_Description", employee.EmpGender_ID);
            ViewBag.EmpTitle_ID = new SelectList(db.Employee_Title, "EmpTitle_ID", "Title_Description", employee.EmpTitle_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "UserName", employee.User_ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,User_ID,Employee_Name,Employee_Surname,Employee_Address,Emp_Phone,Emp_Email,ID_Number,EmpTitle_ID,EmpGender_ID,ImageData")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpGender_ID = new SelectList(db.Employee_Gender, "EmpGender_ID", "Gender_Description", employee.EmpGender_ID);
            ViewBag.EmpTitle_ID = new SelectList(db.Employee_Title, "EmpTitle_ID", "Title_Description", employee.EmpTitle_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "UserName", employee.User_ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
