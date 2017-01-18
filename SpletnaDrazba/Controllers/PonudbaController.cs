using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpletnaDrazba.Models;

namespace SpletnaDrazba.Controllers
{
    public class PonudbaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ponudba
       /* public ActionResult Index()
        {
            return View(db.Ponudba.ToList());
        }*/

       
        public ActionResult Index(int id)
        {
            List<Ponudba> ponudbe = db.Ponudba.Where(p => p.Drazba.Id == id).ToList();
            /*if (ponudbe.Count <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/

            return View(ponudbe);
        }

        // GET: Ponudba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponudba ponudba = db.Ponudba.Find(id);
            if (ponudba == null)
            {
                return HttpNotFound();
            }
            return View(ponudba);
        }

        // GET: Ponudba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ponudba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Znesek,DatumOddaje")] Ponudba ponudba)
        {
            if (ModelState.IsValid)
            {
                
                db.Ponudba.Add(ponudba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ponudba);
        }

        // GET: Ponudba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponudba ponudba = db.Ponudba.Find(id);
            if (ponudba == null)
            {
                return HttpNotFound();
            }
            return View(ponudba);
        }

        // POST: Ponudba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Znesek,DatumOddaje")] Ponudba ponudba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponudba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ponudba);
        }

        // GET: Ponudba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponudba ponudba = db.Ponudba.Find(id);
            if (ponudba == null)
            {
                return HttpNotFound();
            }
            return View(ponudba);
        }

        // POST: Ponudba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ponudba ponudba = db.Ponudba.Find(id);
            db.Ponudba.Remove(ponudba);
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
