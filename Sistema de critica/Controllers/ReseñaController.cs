using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_de_critica;

namespace Sistema_de_critica.Controllers
{
    public class ReseñaController : Controller
    {
        private SistemaDeCriticaBDEntities1 db = new SistemaDeCriticaBDEntities1();

        // GET: Reseña
        public ActionResult Index()
        {
            var reseña = db.Reseña.Include(r => r.Categoria).Include(r => r.Usuario);
            return View(reseña.ToList());
        }

        // GET: Reseña/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseña reseña = db.Reseña.Find(id);
            if (reseña == null)
            {
                return HttpNotFound();
            }
            return View(reseña);
        }

        // GET: Reseña/Create
        public ActionResult Create()
        {
            ViewBag.Categoria_IdCategoria = new SelectList(db.Categoria, "IdCategoria", "nombre_categoria");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario");
            return View();
        }

        // POST: Reseña/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReseña,titulo_reseña,contenido_reseña,puntuacion_reseña,fecha_reseña,UsuarioId,Categoria_IdCategoria")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                db.Reseña.Add(reseña);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria_IdCategoria = new SelectList(db.Categoria, "IdCategoria", "nombre_categoria", reseña.Categoria_IdCategoria);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", reseña.UsuarioId);
            return View(reseña);
        }

        // GET: Reseña/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseña reseña = db.Reseña.Find(id);
            if (reseña == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria_IdCategoria = new SelectList(db.Categoria, "IdCategoria", "nombre_categoria", reseña.Categoria_IdCategoria);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", reseña.UsuarioId);
            return View(reseña);
        }

        // POST: Reseña/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReseña,titulo_reseña,contenido_reseña,puntuacion_reseña,fecha_reseña,UsuarioId,Categoria_IdCategoria")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reseña).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria_IdCategoria = new SelectList(db.Categoria, "IdCategoria", "nombre_categoria", reseña.Categoria_IdCategoria);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", reseña.UsuarioId);
            return View(reseña);
        }

        // GET: Reseña/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseña reseña = db.Reseña.Find(id);
            if (reseña == null)
            {
                return HttpNotFound();
            }
            return View(reseña);
        }

        // POST: Reseña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reseña reseña = db.Reseña.Find(id);
            db.Reseña.Remove(reseña);
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
