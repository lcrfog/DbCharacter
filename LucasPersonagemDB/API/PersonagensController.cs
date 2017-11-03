using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LucasPersonagemDB.Models;
using LucasPersonagemDB.Models.Contexto;

namespace LucasPersonagemDB.API
{
    public class PersonagensController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Personagens
        public IQueryable<Personagem> GetPersonagems()
        {
            return db.Personagems;
        }

        // GET: api/Personagens/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult GetPersonagem(int id)
        {
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            return Ok(personagem);
        }

        // PUT: api/Personagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonagem(int id, Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personagem.PersonagemID)
            {
                return BadRequest();
            }

            db.Entry(personagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personagens
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult PostPersonagem(Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personagems.Add(personagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personagem.PersonagemID }, personagem);
        }

        // DELETE: api/Personagens/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult DeletePersonagem(int id)
        {
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            db.Personagems.Remove(personagem);
            db.SaveChanges();

            return Ok(personagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonagemExists(int id)
        {
            return db.Personagems.Count(e => e.PersonagemID == id) > 0;
        }
    }
}