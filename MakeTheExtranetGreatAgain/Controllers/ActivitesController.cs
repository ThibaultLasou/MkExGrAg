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
    public class ActivitesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Activites
        public IQueryable<Activites> GetActivites()
        {
            return db.Activites;
        }

        // GET: api/Activites/5
        [ResponseType(typeof(Activites))]
        public IHttpActionResult GetActivites(int id)
        {
            Activites activites = db.Activites.Find(id);
            if (activites == null)
            {
                return NotFound();
            }

            return Ok(activites);
        }

        // PUT: api/Activites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivites(int id, Activites activites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activites.Id)
            {
                return BadRequest();
            }

            db.Entry(activites).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitesExists(id))
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

        // POST: api/Activites
        [ResponseType(typeof(Activites))]
        public IHttpActionResult PostActivites(Activites activites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activites.Add(activites);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActivitesExists(activites.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = activites.Id }, activites);
        }

        // DELETE: api/Activites/5
        [ResponseType(typeof(Activites))]
        public IHttpActionResult DeleteActivites(int id)
        {
            Activites activites = db.Activites.Find(id);
            if (activites == null)
            {
                return NotFound();
            }

            db.Activites.Remove(activites);
            db.SaveChanges();

            return Ok(activites);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivitesExists(int id)
        {
            return db.Activites.Count(e => e.Id == id) > 0;
        }
    }
}