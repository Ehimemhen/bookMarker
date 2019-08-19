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
    public class BooksController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        // GET: Books
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "BookTitle")
            {
                return View(db.Books.Where(x => x.Book_Title.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "BookAuthor")
            {
                return View(db.Books.Where(x => x.Book_Author.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "ISBN")
            {
                return View(db.Books.Where(x => x.ISBN.Contains(search) || search == null).ToList());
            }



            else
            {
                return View(db.Books.ToList());
            }


        }


        //public ActionResult Index()
        //{
        //    var books = db.Books.Include(b => b.Book_Status);
        //    return View(books.ToList());
        //}

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.BookStatus_ID = new SelectList(db.Book_Status, "BookStatus_ID", "BookStatus_Description");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_ID,Book_Title,Book_Author,ISBN,Book_Edition,BookStatus_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookStatus_ID = new SelectList(db.Book_Status, "BookStatus_ID", "BookStatus_Description", book.BookStatus_ID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookStatus_ID = new SelectList(db.Book_Status, "BookStatus_ID", "BookStatus_Description", book.BookStatus_ID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_ID,Book_Title,Book_Author,ISBN,Book_Edition,BookStatus_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookStatus_ID = new SelectList(db.Book_Status, "BookStatus_ID", "BookStatus_Description", book.BookStatus_ID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
