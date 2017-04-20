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
    public class GroupesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Groupes
        public IQueryable<Groupes> GetGroupes()
        {
            return db.Groupes;
        }

        // GET: api/Groupes/5
        [ResponseType(typeof(Groupes))]
        public IHttpActionResult GetGroupes(int id)
        {
            Groupes groupes = db.Groupes.Find(id);
            if (groupes == null)
            {
                return NotFound();
            }

            return Ok(groupes);
        }

        // PUT: api/Groupes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupes(int id, Groupes groupes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupes.Id)
            {
                return BadRequest();
            }

            db.Entry(groupes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupesExists(id))
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

        // POST: api/Groupes
        [ResponseType(typeof(Groupes))]
        public IHttpActionResult PostGroupes(Groupes groupes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groupes.Add(groupes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupesExists(groupes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupes.Id }, groupes);
        }

        // DELETE: api/Groupes/5
        [ResponseType(typeof(Groupes))]
        public IHttpActionResult DeleteGroupes(int id)
        {
            Groupes groupes = db.Groupes.Find(id);
            if (groupes == null)
            {
                return NotFound();
            }

            db.Groupes.Remove(groupes);
            db.SaveChanges();

            return Ok(groupes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupesExists(int id)
        {
            return db.Groupes.Count(e => e.Id == id) > 0;
        }
    }
}