using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITSDriverApplication.App_Code;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.Controllers
{
    public class ApplicationsController : Controller
    {
        private ITSDriverContext db = new ITSDriverContext();

        // GET: Applications
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Driver);
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "Regis_ID");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_ID,Driver_ID,Create_Date,Application_Status,Approval_Date,Approval_Duration,Approval_Exp_Date,Approver_LName,Approver_FName,University_Vehicle,Rental_Vehicle,Personal_Vehicle,Multi_Person_Vehicle,Comments")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "Regis_ID", application.Driver_ID);
            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "Regis_ID", application.Driver_ID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_ID,Driver_ID,Create_Date,Application_Status,Approval_Date,Approval_Duration,Approval_Exp_Date,Approver_LName,Approver_FName,University_Vehicle,Rental_Vehicle,Personal_Vehicle,Multi_Person_Vehicle,Comments")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Driver_ID = new SelectList(db.Drivers, "Driver_ID", "Regis_ID", application.Driver_ID);
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
