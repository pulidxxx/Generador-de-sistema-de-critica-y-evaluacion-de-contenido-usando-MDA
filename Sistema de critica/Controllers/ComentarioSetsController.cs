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
    public class ComentarioSetsController : Controller
    {
        private SistemaDeCriticaBDEntities1 db = new SistemaDeCriticaBDEntities1();

        // GET: ComentarioSets
        public ActionResult Index()
        {
            var comentarioSet = db.ComentarioSet.Include(c => c.Reseña).Include(c => c.Usuario);
            return View(comentarioSet.ToList());
        }

        // GET: ComentarioSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioSet comentarioSet = db.ComentarioSet.Find(id);
            if (comentarioSet == null)
            {
                return HttpNotFound();
            }
            return View(comentarioSet);
        }

        // GET: ComentarioSets/Create
        public ActionResult Create()
        {
            ViewBag.ReseñaIdReseña = new SelectList(db.Reseña, "IdReseña", "titulo_reseña");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario");
            return View();
        }

        // POST: ComentarioSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComentario,contenido_comentario,UsuarioId,ReseñaIdReseña")] ComentarioSet comentarioSet)
        {
            if (ModelState.IsValid)
            {
                db.ComentarioSet.Add(comentarioSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReseñaIdReseña = new SelectList(db.Reseña, "IdReseña", "titulo_reseña", comentarioSet.ReseñaIdReseña);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", comentarioSet.UsuarioId);
            return View(comentarioSet);
        }

        // GET: ComentarioSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioSet comentarioSet = db.ComentarioSet.Find(id);
            if (comentarioSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReseñaIdReseña = new SelectList(db.Reseña, "IdReseña", "titulo_reseña", comentarioSet.ReseñaIdReseña);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", comentarioSet.UsuarioId);
            return View(comentarioSet);
        }

        // POST: ComentarioSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentario,contenido_comentario,UsuarioId,ReseñaIdReseña")] ComentarioSet comentarioSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarioSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReseñaIdReseña = new SelectList(db.Reseña, "IdReseña", "titulo_reseña", comentarioSet.ReseñaIdReseña);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "nombre_usuario", comentarioSet.UsuarioId);
            return View(comentarioSet);
        }

        // GET: ComentarioSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComentarioSet comentarioSet = db.ComentarioSet.Find(id);
            if (comentarioSet == null)
            {
                return HttpNotFound();
            }
            return View(comentarioSet);
        }

        // POST: ComentarioSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioSet comentarioSet = db.ComentarioSet.Find(id);
            db.ComentarioSet.Remove(comentarioSet);
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
