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
    public class TâchesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Tâches
        public IQueryable<Tâches> GetTâches()
        {
            return db.Tâches;
        }

        // GET: api/Tâches/5
        [ResponseType(typeof(Tâches))]
        public IHttpActionResult GetTâches(int id)
        {
            Tâches tâches = db.Tâches.Find(id);
            if (tâches == null)
            {
                return NotFound();
            }

            return Ok(tâches);
        }

        // PUT: api/Tâches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTâches(int id, Tâches tâches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tâches.Id)
            {
                return BadRequest();
            }

            db.Entry(tâches).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TâchesExists(id))
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

        // POST: api/Tâches
        [ResponseType(typeof(Tâches))]
        public IHttpActionResult PostTâches(Tâches tâches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tâches.Add(tâches);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TâchesExists(tâches.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tâches.Id }, tâches);
        }

        // DELETE: api/Tâches/5
        [ResponseType(typeof(Tâches))]
        public IHttpActionResult DeleteTâches(int id)
        {
            Tâches tâches = db.Tâches.Find(id);
            if (tâches == null)
            {
                return NotFound();
            }

            db.Tâches.Remove(tâches);
            db.SaveChanges();

            return Ok(tâches);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TâchesExists(int id)
        {
            return db.Tâches.Count(e => e.Id == id) > 0;
        }
    }
}