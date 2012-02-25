using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conjunctor.Mvc.Models;

namespace Conjunctor.Mvc.Controllers
{
    public class MeetingsController : Controller
    {
        private ConjunctorContext db = new ConjunctorContext();

        //
        // GET: /Meetings/

        public ActionResult Index()
        {
            var today = DateTime.Today;
            var twoWeeksPrior = today.AddDays(-14);
            var twoWeeksForward = today.AddDays(14);

            var meetings = from m in db.Meetings
                           orderby m.Date descending
                           where (m.Date >= today && m.Date <= twoWeeksForward) ||
                            (m.Date <= today && m.Date >= twoWeeksPrior)
                           select m;

            return View(meetings.ToList());
        }

        //
        // GET: /Meetings/Details/5

        public ActionResult Details(int id = 0)
        {
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        //
        // GET: /Meetings/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Meetings/Create

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meeting);
        }

        //
        // GET: /Meetings/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        //
        // POST: /Meetings/Edit/5

        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        //
        // GET: /Meetings/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        //
        // POST: /Meetings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = db.Meetings.Find(id);
            db.Meetings.Remove(meeting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}