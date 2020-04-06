using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prog3;

namespace Prog3.Controllers
{
    public class EntradasController : Controller
    {
        private FinalPrEntities db = new FinalPrEntities();

        // GET: Entradas
        public ActionResult Index()
        {
            var entradas = db.Entradas.Include(e => e.Producto).Include(e => e.Proveedor);
            return View(entradas.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = db.Entradas.Find(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            return View(entradas);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre");
            return View();
        }

        // POST: Entradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntrada,IdProducto,IdProveedor,Cantidad,Fecha")] Entradas entradas)
        {
            if (ModelState.IsValid)
            {
                db.Entradas.Add(entradas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", entradas.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", entradas.IdProveedor);
            return View(entradas);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = db.Entradas.Find(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", entradas.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", entradas.IdProveedor);
            return View(entradas);
        }

        // POST: Entradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntrada,IdProducto,IdProveedor,Cantidad,Fecha")] Entradas entradas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", entradas.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", entradas.IdProveedor);
            return View(entradas);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = db.Entradas.Find(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            return View(entradas);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entradas entradas = db.Entradas.Find(id);
            db.Entradas.Remove(entradas);
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
