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
    public class CoursController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cours
        public IQueryable<Cours> GetCours()
        {
            return db.Cours;
        }

        // GET: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult GetCours(int id)
        {
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            return Ok(cours);
        }

        // PUT: api/Cours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCours(int id, Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cours.Id)
            {
                return BadRequest();
            }

            db.Entry(cours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(id))
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

        // POST: api/Cours
        [ResponseType(typeof(Cours))]
        public IHttpActionResult PostCours(Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cours.Add(cours);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CoursExists(cours.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cours.Id }, cours);
        }

        // DELETE: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult DeleteCours(int id)
        {
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.Cours.Remove(cours);
            db.SaveChanges();

            return Ok(cours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursExists(int id)
        {
            return db.Cours.Count(e => e.Id == id) > 0;
        }
    }
}