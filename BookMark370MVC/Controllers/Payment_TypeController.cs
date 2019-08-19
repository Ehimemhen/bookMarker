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
    public class Payment_TypeController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                return View(db.Payment_Type.Where(x => x.PaymentType_Name.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Description")
            {
                return View(db.Payment_Type.Where(x => x.PaymentType_Description.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Payment_Type.ToList());
            }


        }

        // GET: Payment_Type
        //public ActionResult Index()
        //{
        //    return View(db.Payment_Type.ToList());
        //}

        // GET: Payment_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Type payment_Type = db.Payment_Type.Find(id);
            if (payment_Type == null)
            {
                return HttpNotFound();
            }
            return View(payment_Type);
        }

        // GET: Payment_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentType_ID,PaymentType_Name,PaymentType_Description")] Payment_Type payment_Type)
        {
            if (ModelState.IsValid)
            {
                db.Payment_Type.Add(payment_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payment_Type);
        }

        // GET: Payment_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Type payment_Type = db.Payment_Type.Find(id);
            if (payment_Type == null)
            {
                return HttpNotFound();
            }
            return View(payment_Type);
        }

        // POST: Payment_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentType_ID,PaymentType_Name,PaymentType_Description")] Payment_Type payment_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment_Type);
        }

        // GET: Payment_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Type payment_Type = db.Payment_Type.Find(id);
            if (payment_Type == null)
            {
                return HttpNotFound();
            }
            return View(payment_Type);
        }

        // POST: Payment_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment_Type payment_Type = db.Payment_Type.Find(id);
            db.Payment_Type.Remove(payment_Type);
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
