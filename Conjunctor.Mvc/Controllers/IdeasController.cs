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
    public class IdeasController : Controller
    {
        private ConjunctorContext db = new ConjunctorContext();

        //
        // GET: /Ideas/

        public ActionResult Index()
        {
            return View(db.Ideas.OrderBy(i => i.Title).ToList());
        }

        //
        // GET: /Ideas/Details/5

        public ActionResult Details(int id = 0)
        {
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        //
        // GET: /Ideas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ideas/Create

        [HttpPost]
        public ActionResult Create(Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Ideas.Add(idea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idea);
        }

        //
        // GET: /Ideas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        //
        // POST: /Ideas/Edit/5

        [HttpPost]
        public ActionResult Edit(Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea);
        }

        //
        // GET: /Ideas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        //
        // POST: /Ideas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Idea idea = db.Ideas.Find(id);
            db.Ideas.Remove(idea);
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