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
using MakeTheExtranetGreatAgain;
using MakeTheExtranetGreatAgain.Models;

namespace MakeTheExtranetGreatAgain.Controllers
{
    public class Sous_doc_WebController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sous_doc_Web
        public IQueryable<Sous_doc_Web> GetSous_doc_Web()
        {
            return db.Sous_doc_Web;
        }

        // GET: api/Sous_doc_Web/5
        [ResponseType(typeof(Sous_doc_Web))]
        public IHttpActionResult GetSous_doc_Web(int id)
        {
            Sous_doc_Web sous_doc_Web = db.Sous_doc_Web.Find(id);
            if (sous_doc_Web == null)
            {
                return NotFound();
            }

            return Ok(sous_doc_Web);
        }

        // PUT: api/Sous_doc_Web/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSous_doc_Web(int id, Sous_doc_Web sous_doc_Web)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sous_doc_Web.Id)
            {
                return BadRequest();
            }

            db.Entry(sous_doc_Web).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sous_doc_WebExists(id))
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

        // POST: api/Sous_doc_Web
        [ResponseType(typeof(Sous_doc_Web))]
        public IHttpActionResult PostSous_doc_Web(Sous_doc_Web sous_doc_Web)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sous_doc_Web.Add(sous_doc_Web);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Sous_doc_WebExists(sous_doc_Web.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sous_doc_Web.Id }, sous_doc_Web);
        }

        // DELETE: api/Sous_doc_Web/5
        [ResponseType(typeof(Sous_doc_Web))]
        public IHttpActionResult DeleteSous_doc_Web(int id)
        {
            Sous_doc_Web sous_doc_Web = db.Sous_doc_Web.Find(id);
            if (sous_doc_Web == null)
            {
                return NotFound();
            }

            db.Sous_doc_Web.Remove(sous_doc_Web);
            db.SaveChanges();

            return Ok(sous_doc_Web);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sous_doc_WebExists(int id)
        {
            return db.Sous_doc_Web.Count(e => e.Id == id) > 0;
        }
    }
}