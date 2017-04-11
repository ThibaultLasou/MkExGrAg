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
    public class StatutsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Statuts
        public IQueryable<Statut> GetStatuts()
        {
            return db.Statuts;
        }

        // GET: api/Statuts/5
        [ResponseType(typeof(Statut))]
        public IHttpActionResult GetStatut(int id)
        {
            Statut statut = db.Statuts.Find(id);
            if (statut == null)
            {
                return NotFound();
            }

            return Ok(statut);
        }

        // PUT: api/Statuts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatut(int id, Statut statut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statut.Id)
            {
                return BadRequest();
            }

            db.Entry(statut).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatutExists(id))
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

        // POST: api/Statuts
        [ResponseType(typeof(Statut))]
        public IHttpActionResult PostStatut(Statut statut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statuts.Add(statut);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StatutExists(statut.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = statut.Id }, statut);
        }

        // DELETE: api/Statuts/5
        [ResponseType(typeof(Statut))]
        public IHttpActionResult DeleteStatut(int id)
        {
            Statut statut = db.Statuts.Find(id);
            if (statut == null)
            {
                return NotFound();
            }

            db.Statuts.Remove(statut);
            db.SaveChanges();

            return Ok(statut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatutExists(int id)
        {
            return db.Statuts.Count(e => e.Id == id) > 0;
        }
    }
}