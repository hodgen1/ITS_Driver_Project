﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITSDriverApplication.DAL;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.Controllers
{
    public class DriversController : Controller
    {
        private ITSDriverContext db = new ITSDriverContext();

        // GET: Drivers
        public ActionResult Index()
        {
            var drivers = db.Drivers.Include(d => d.Supervisor);
            return View(drivers.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            ViewBag.Supervisor_ID = new SelectList(db.Supervisors, "Supervisor_ID", "First_Name");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Driver_ID,Regis_ID,First_Name,Last_Name,Middle_Initial,DOB,Primary_Phone,Alternate_Phone,Email,Driver_Type,Driver_Status,DL_Number,DL_State,DL_Exp_Date,Ins_Name,Ins_Policy_Number,Ins_Policy_Exp_Date,Supervisor_ID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Supervisor_ID = new SelectList(db.Supervisors, "Supervisor_ID", "First_Name", driver.Supervisor_ID);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.Supervisor_ID = new SelectList(db.Supervisors, "Supervisor_ID", "First_Name", driver.Supervisor_ID);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Driver_ID,Regis_ID,First_Name,Last_Name,Middle_Initial,DOB,Primary_Phone,Alternate_Phone,Email,Driver_Type,Driver_Status,DL_Number,DL_State,DL_Exp_Date,Ins_Name,Ins_Policy_Number,Ins_Policy_Exp_Date,Supervisor_ID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Supervisor_ID = new SelectList(db.Supervisors, "Supervisor_ID", "First_Name", driver.Supervisor_ID);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
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
