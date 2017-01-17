﻿using System;
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
            if (drazba == null)
            {
                return HttpNotFound();
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
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), filename + drazba.Id.ToString());
                string semicolumn = "";
                if (count > 0)
                    semicolumn = ";";
                filePathList = filePathList+semicolumn+"~/Content/images/"+ trenutniID + 1.ToString() + filename;
                file.SaveAs(path);
                count++;
            }
            if (ModelState.IsValid)
            {
                drazba.Slike = filePathList;
                db.Drazbas.Add(drazba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drazba);
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