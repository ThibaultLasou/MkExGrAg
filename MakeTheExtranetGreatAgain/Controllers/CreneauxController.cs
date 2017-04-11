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
    public class CreneauxController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Creneaux
        public IQueryable<Creneaux> GetCreneaux()
        {
            return db.Creneaux;
        }

        // GET: api/Creneaux/5
        [ResponseType(typeof(Creneaux))]
        public IHttpActionResult GetCreneaux(DateTime id)
        {
            Creneaux creneaux = db.Creneaux.Find(id);
            if (creneaux == null)
            {
                return NotFound();
            }

            return Ok(creneaux);
        }

        // PUT: api/Creneaux/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreneaux(DateTime id, Creneaux creneaux)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creneaux.debut)
            {
                return BadRequest();
            }

            db.Entry(creneaux).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreneauxExists(id))
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

        // POST: api/Creneaux
        [ResponseType(typeof(Creneaux))]
        public IHttpActionResult PostCreneaux(Creneaux creneaux)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Creneaux.Add(creneaux);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CreneauxExists(creneaux.debut))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = creneaux.debut }, creneaux);
        }

        // DELETE: api/Creneaux/5
        [ResponseType(typeof(Creneaux))]
        public IHttpActionResult DeleteCreneaux(DateTime id)
        {
            Creneaux creneaux = db.Creneaux.Find(id);
            if (creneaux == null)
            {
                return NotFound();
            }

            db.Creneaux.Remove(creneaux);
            db.SaveChanges();

            return Ok(creneaux);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CreneauxExists(DateTime id)
        {
            return db.Creneaux.Count(e => e.debut == id) > 0;
        }
    }
}