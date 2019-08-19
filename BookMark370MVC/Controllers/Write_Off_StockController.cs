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
    public class Write_Off_StockController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        // GET: Write_Off_Stock
        public ActionResult Index()
        {
            var write_Off_Stock = db.Write_Off_Stock.Include(w => w.Inventory);
            return View(write_Off_Stock.ToList());
        }

        // GET: Write_Off_Stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Write_Off_Stock write_Off_Stock = db.Write_Off_Stock.Find(id);
            if (write_Off_Stock == null)
            {
                return HttpNotFound();
            }
            return View(write_Off_Stock);
        }

        // GET: Write_Off_Stock/Create
        public ActionResult Create()
        {
            ViewBag.Inventory_ID = new SelectList(db.Inventories, "Inventory_ID", "Inventory_Name");
            return View();
        }

        // POST: Write_Off_Stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Write_Off_ID,Inventory_ID")] Write_Off_Stock write_Off_Stock)
        {
            if (ModelState.IsValid)
            {
                db.Write_Off_Stock.Add(write_Off_Stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Inventory_ID = new SelectList(db.Inventories, "Inventory_ID", "Inventory_Name", write_Off_Stock.Inventory_ID);
            return View(write_Off_Stock);
        }

        // GET: Write_Off_Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Write_Off_Stock write_Off_Stock = db.Write_Off_Stock.Find(id);
            if (write_Off_Stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.Inventory_ID = new SelectList(db.Inventories, "Inventory_ID", "Inventory_Name", write_Off_Stock.Inventory_ID);
            return View(write_Off_Stock);
        }

        // POST: Write_Off_Stock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Write_Off_ID,Inventory_ID")] Write_Off_Stock write_Off_Stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(write_Off_Stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Inventory_ID = new SelectList(db.Inventories, "Inventory_ID", "Inventory_Name", write_Off_Stock.Inventory_ID);
            return View(write_Off_Stock);
        }

        // GET: Write_Off_Stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Write_Off_Stock write_Off_Stock = db.Write_Off_Stock.Find(id);
            if (write_Off_Stock == null)
            {
                return HttpNotFound();
            }
            return View(write_Off_Stock);
        }

        // POST: Write_Off_Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Write_Off_Stock write_Off_Stock = db.Write_Off_Stock.Find(id);
            db.Write_Off_Stock.Remove(write_Off_Stock);
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
