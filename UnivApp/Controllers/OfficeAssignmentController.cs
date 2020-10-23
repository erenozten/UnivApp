using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.Models;

namespace UnivApp.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private UnivAppContext db = new UnivAppContext();

        // GET: OfficeAssignment
        public async Task<ActionResult> Index()
        {
            var officeAssignments = db.OfficeAssignments.Include(o => o.Instructor);
            return View(await officeAssignments.ToListAsync());
        }

        // GET: OfficeAssignment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = await db.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }

            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Create
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.People, "ID", "Fullname");
            return View();
        }

        // POST: OfficeAssignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InstructorID,Location")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                db.OfficeAssignments.Add(officeAssignment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.People, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = await db.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.People, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // POST: OfficeAssignment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InstructorID,Location")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                //var willDeletedOffAssignment = db.OfficeAssignments.Find(officeAssignment.InstructorID);
                //db.OfficeAssignments.Remove(willDeletedOffAssignment);
                //var newOfficeAssignment = new OfficeAssignment();

                //newOfficeAssignment.InstructorID = officeAssignment.InstructorID;
                //newOfficeAssignment.Location = officeAssignment.Location;
                //db.OfficeAssignments.Add(newOfficeAssignment);

                var offAssignment = db.OfficeAssignments.Find(officeAssignment.InstructorID);
                offAssignment.Location = officeAssignment.Location;
                db.Entry(offAssignment).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.People, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = await db.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }
            return View(officeAssignment);
        }

        // POST: OfficeAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OfficeAssignment officeAssignment = await db.OfficeAssignments.FindAsync(id);
            db.OfficeAssignments.Remove(officeAssignment);
            await db.SaveChangesAsync();
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
