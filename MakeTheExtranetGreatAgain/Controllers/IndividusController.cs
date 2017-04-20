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
    public class IndividusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Individus
        public IQueryable<Individus> GetIndividus()
        {
            return db.Individus;
        }

        // GET: api/Individus/5
        [ResponseType(typeof(Individus))]
        public IHttpActionResult GetIndividus(int id)
        {
            Individus individus = db.Individus.Find(id);
            if (individus == null)
            {
                return NotFound();
            }

            return Ok(individus);
        }

        // PUT: api/Individus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndividus(int id, Individus individus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != individus.Id)
            {
                return BadRequest();
            }

            db.Entry(individus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividusExists(id))
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

        // POST: api/Individus
        [ResponseType(typeof(Individus))]
        public IHttpActionResult PostIndividus(Individus individus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Individus.Add(individus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IndividusExists(individus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = individus.Id }, individus);
        }

        // DELETE: api/Individus/5
        [ResponseType(typeof(Individus))]
        public IHttpActionResult DeleteIndividus(int id)
        {
            Individus individus = db.Individus.Find(id);
            if (individus == null)
            {
                return NotFound();
            }

            db.Individus.Remove(individus);
            db.SaveChanges();

            return Ok(individus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndividusExists(int id)
        {
            return db.Individus.Count(e => e.Id == id) > 0;
        }
    }
}