using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealershipMgr.DAL;
using DealershipMgr.Models;

namespace DealershipMgr.Controllers
{
    public class SalespersonController : Controller
    {
        private DealerMgrContext db = new DealerMgrContext();

        // GET: Salesperson
        public ActionResult Index()
        {
            var salespersons = db.Salespersons.Include(c => c.Location);
            return View(db.Salespersons.ToList());
        }

        // GET: Salesperson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // GET: Salesperson/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName");
            return View();
        }

        // POST: Salesperson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,HireDate,SalesYtd,SalesGoal,MetSalesGoal,LocationID")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Salespersons.Add(salesperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", salesperson.LocationID);
            return View(salesperson);
        }

        // GET: Salesperson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", salesperson.LocationID);
            return View(salesperson);
        }

        // POST: Salesperson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,HireDate,SalesYtd,SalesGoal,MetSalesGoal")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesperson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", salesperson.LocationID);
            return View(salesperson);
        }

        // GET: Salesperson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salespersons.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // POST: Salesperson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesperson salesperson = db.Salespersons.Find(id);
            db.Salespersons.Remove(salesperson);
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
