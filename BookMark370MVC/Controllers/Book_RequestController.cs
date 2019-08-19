﻿using System;
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
    public class Book_RequestController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        // GET: Book_Request
        //public ActionResult Index()
        //{
        //    var book_Request = db.Book_Request;
        //    return View(book_Request.ToList());
        //}

        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "BookTitle")
            {
                return View(db.Book_Request.Where(x => x.Book_Title.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "BookAuthor")
            {
                return View(db.Book_Request.Where(x => x.Book_Author.StartsWith(search) || search == null).ToList());
            }
            //else if (searchBy == "BookEdition")
            //{
            //    return View(db.Book_Request.Where(x => x.Book_Edition.StartsWith(search) || search == null).ToList());
            //}
            else
            {
                return View(db.Book_Request.Where(x => x.Book_Edition.Contains(search) || search == null).ToList());
            }


        }

        // GET: Book_Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Request book_Request = db.Book_Request.Find(id);
            if (book_Request == null)
            {
                return HttpNotFound();
            }
            return View(book_Request);
        }

        // GET: Book_Request/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name");
            return View();
        }

        // POST: Book_Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_Request_ID,Customer_ID,Book_Title,Book_Author,Book_Edition,Book_Request_Description,Customer_Name,Customer_Surname,Customer_Phone")] Book_Request book_Request)
        {
            if (ModelState.IsValid)
            {
                db.Book_Request.Add(book_Request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", book_Request.Customer_ID);
            return View(book_Request);
        }

        // GET: Book_Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Request book_Request = db.Book_Request.Find(id);
            if (book_Request == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", book_Request.Customer_ID);
            return View(book_Request);
        }

        // POST: Book_Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_Request_ID,Customer_ID,Book_Title,Book_Author,Book_Edition,Book_Request_Description,Customer_Name,Customer_Surname,Customer_Phone")] Book_Request book_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", book_Request.Customer_ID);
            return View(book_Request);
        }

        // GET: Book_Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Request book_Request = db.Book_Request.Find(id);
            if (book_Request == null)
            {
                return HttpNotFound();
            }
            return View(book_Request);
        }

        // POST: Book_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Request book_Request = db.Book_Request.Find(id);
            db.Book_Request.Remove(book_Request);
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
