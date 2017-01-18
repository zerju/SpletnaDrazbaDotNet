using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpletnaDrazba.Models;

namespace SpletnaDrazba.Controllers
{
    public class DrazbaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drazba
        public ActionResult Index()
        {
            return View(db.Drazbas.ToList());
        }

        // GET: Drazba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drazba drazba = db.Drazbas.Find(id);
            
            var ponudbe = db.Ponudba.Where(p => p.Drazba.Id == id);
            var zadnjaPonudba = ponudbe.OrderByDescending(p => p.Id).FirstOrDefault();
            
            if (drazba == null)
            {
                return HttpNotFound();
            }
            if (zadnjaPonudba == null)
            {
                ViewData["trenutnaPonudba"] = drazba.ZacetnaCena;
                double visanjePonudbe = drazba.ZacetnaCena / 10;

                ViewData["minPonudba"] = Math.Round(drazba.ZacetnaCena + visanjePonudbe);
            }
            else
            {
                ViewData["trenutnaPonudba"] = zadnjaPonudba.Znesek;
                decimal visanjePonudbe = zadnjaPonudba.Znesek / 10;
                ViewData["minPonudba"] = Math.Round(zadnjaPonudba.Znesek + visanjePonudbe);
            }
            return View(drazba);
        }

        // GET: Drazba/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Drazba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DatumOd,DatumDo,Ime,NazivPredmeta,Uporabnik,Opis,ZacetnaCena,Kategorija")] Drazba drazba, Picture picture)
        {
            string filePathList = "";
            int count = 0;
            int trenutniID = db.Drazbas.Max(item => item.Id)+1;
            foreach (var file in picture.Files)
            {
                if(file != null) { 
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), +trenutniID + filename);
                    string semicolumn = "";
                    if (count > 0)
                        semicolumn = ";";
                    filePathList = filePathList+semicolumn+"~/Content/images/"+ trenutniID + filename;
                    file.SaveAs(path);
                }
                count++;
            }
            if (ModelState.IsValid)
            {
                drazba.Slike = filePathList;
                var userId = Session["CurrentUserID"];
                ApplicationUser user = db.Users.Find(userId);
                drazba.User = user;
                db.Drazbas.Add(drazba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drazba);
        }

        [HttpGet]
        public ActionResult OddajPonudbo(int id,decimal znesek)
        {
            Drazba drazba = db.Drazbas.Single(d => d.Id == id);
            Ponudba ponudba = new Ponudba();
            ponudba.Drazba = drazba;
            ponudba.Znesek = znesek;
            var userId = Session["CurrentUserID"];
            var user = db.Users.Find(userId);
            ponudba.User = user;
            ponudba.DatumOddaje = DateTime.Now;
            db.Ponudba.Add(ponudba);
            db.SaveChanges();
            return RedirectToAction("Details/"+id.ToString());
        }

        // GET: Drazba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drazba drazba = db.Drazbas.Find(id);
            if (drazba == null)
            {
                return HttpNotFound();
            }
            return View(drazba);
        }

        // POST: Drazba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DatumOd,DatumDo,Ime,NazivPredmeta,Uporabnik,Opis,ZacetnaCena,Kategorija")] Drazba drazba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drazba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drazba);
        }

        /*[HttpPost]
        public ActionResult Create(Picture picture)
        {
            foreach (var file in picture.Files)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"),filename);
                file.SaveAs(path);
            }
            return RedirectToAction("Create");
        }*/

        // GET: Drazba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drazba drazba = db.Drazbas.Find(id);
            if (drazba == null)
            {
                return HttpNotFound();
            }
            return View(drazba);
        }

        // POST: Drazba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drazba drazba = db.Drazbas.Find(id);
            db.Drazbas.Remove(drazba);
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
