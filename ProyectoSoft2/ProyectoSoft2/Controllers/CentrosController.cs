using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSoft2.DB;

namespace ProyectoSoft2.Controllers
{
    public class CentrosController : Controller
    {
        private courageproEntities db = new courageproEntities();

        // GET: Centros
        public ActionResult Index()
        {
            return View(db.Centros.ToList());
        }

        // GET: Centros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // GET: Centros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCentro,NombreCentro,Direccion")] Centros centros)
        {
            if (ModelState.IsValid)
            {
                db.Centros.Add(centros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centros);
        }

        // GET: Centros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // POST: Centros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCentro,NombreCentro,Direccion")] Centros centros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centros);
        }

        // GET: Centros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // POST: Centros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Centros centros = db.Centros.Find(id);
            db.Centros.Remove(centros);
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
