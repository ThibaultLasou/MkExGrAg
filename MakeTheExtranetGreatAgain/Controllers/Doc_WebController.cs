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
    public class Doc_WebController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Doc_Web
        public IQueryable<Doc_Web> GetDoc_Web()
        {
            return db.Doc_Web;
        }

        // GET: api/Doc_Web/5
        [ResponseType(typeof(Doc_Web))]
        public IHttpActionResult GetDoc_Web(int id)
        {
            Doc_Web doc_Web = db.Doc_Web.Find(id);
            if (doc_Web == null)
            {
                return NotFound();
            }

            return Ok(doc_Web);
        }

        // PUT: api/Doc_Web/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoc_Web(int id, Doc_Web doc_Web)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doc_Web.Id)
            {
                return BadRequest();
            }

            db.Entry(doc_Web).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Doc_WebExists(id))
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

        // POST: api/Doc_Web
        [ResponseType(typeof(Doc_Web))]
        public IHttpActionResult PostDoc_Web(Doc_Web doc_Web)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doc_Web.Add(doc_Web);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Doc_WebExists(doc_Web.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doc_Web.Id }, doc_Web);
        }

        // DELETE: api/Doc_Web/5
        [ResponseType(typeof(Doc_Web))]
        public IHttpActionResult DeleteDoc_Web(int id)
        {
            Doc_Web doc_Web = db.Doc_Web.Find(id);
            if (doc_Web == null)
            {
                return NotFound();
            }

            db.Doc_Web.Remove(doc_Web);
            db.SaveChanges();

            return Ok(doc_Web);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Doc_WebExists(int id)
        {
            return db.Doc_Web.Count(e => e.Id == id) > 0;
        }
    }
}