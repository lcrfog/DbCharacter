using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LucasPersonagemDB.Models;
using LucasPersonagemDB.Models.Contexto;

namespace LucasPersonagemDB.Controllers
{
    public class PersonagensController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Personagens
        public ActionResult Index()
        {
            return View(db.Personagems.ToList());
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // GET: Personagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonagemID,Nome,Descricao,Sexo,Classe,Raça,Nivel")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Personagems.Add(personagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonagemID,Nome,Descricao,Sexo,Classe,Raça,Nivel")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagem personagem = db.Personagems.Find(id);
            db.Personagems.Remove(personagem);
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
