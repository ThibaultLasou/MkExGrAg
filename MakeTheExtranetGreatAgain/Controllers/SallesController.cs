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
    public class SallesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Salles
        public IQueryable<Salles> GetSalles()
        {
            return db.Salles;
        }

        // GET: api/Salles/5
        [ResponseType(typeof(Salles))]
        public IHttpActionResult GetSalles(int id)
        {
            Salles salles = db.Salles.Find(id);
            if (salles == null)
            {
                return NotFound();
            }

            return Ok(salles);
        }

        // PUT: api/Salles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalles(int id, Salles salles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salles.Id)
            {
                return BadRequest();
            }

            db.Entry(salles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SallesExists(id))
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

        // POST: api/Salles
        [ResponseType(typeof(Salles))]
        public IHttpActionResult PostSalles(Salles salles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salles.Add(salles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SallesExists(salles.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = salles.Id }, salles);
        }

        // DELETE: api/Salles/5
        [ResponseType(typeof(Salles))]
        public IHttpActionResult DeleteSalles(int id)
        {
            Salles salles = db.Salles.Find(id);
            if (salles == null)
            {
                return NotFound();
            }

            db.Salles.Remove(salles);
            db.SaveChanges();

            return Ok(salles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SallesExists(int id)
        {
            return db.Salles.Count(e => e.Id == id) > 0;
        }
    }
}