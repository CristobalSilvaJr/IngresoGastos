using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngresoGastos.Data;
using IngresoGastos.Models;

namespace IngresoGastos.Controllers
{
    public class IngresoGastosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: IngresoGastos
        public ActionResult Index()
        {
            double ingresos,gastos,neto;
            ingresos = db.ingresoGastos.Where(m=> m.EsIngreso==true).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            gastos = db.ingresoGastos.Where(m => m.EsIngreso == false).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            neto = ingresos - gastos;
            ViewBag.Ingreso = ingresos;
            ViewBag.Gastos = gastos;
            ViewBag.Neto = neto;
            return View(db.ingresoGastos.ToList());
        }

        // GET: IngresoGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosModel ingresoGastosModel = db.ingresoGastos.Find(id);
            if (ingresoGastosModel == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosModel);
        }

        // GET: IngresoGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoGastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastosModel ingresoGastosModel)
        {
            if (ModelState.IsValid)
            {
                ingresoGastosModel.FechaIngreso = DateTime.Now;
                db.ingresoGastos.Add(ingresoGastosModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresoGastosModel);
        }

        // GET: IngresoGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosModel ingresoGastosModel = db.ingresoGastos.Find(id);
            if (ingresoGastosModel == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosModel);
        }

        // POST: IngresoGastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastosModel ingresoGastosModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresoGastosModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresoGastosModel);
        }

        // GET: IngresoGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosModel ingresoGastosModel = db.ingresoGastos.Find(id);
            if (ingresoGastosModel == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosModel);
        }

        // POST: IngresoGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoGastosModel ingresoGastosModel = db.ingresoGastos.Find(id);
            db.ingresoGastos.Remove(ingresoGastosModel);
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
