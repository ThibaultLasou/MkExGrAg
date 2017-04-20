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
    public class QuestionnairesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Questionnaires
        public IQueryable<Questionnaires> GetQuestionnaires()
        {
            return db.Questionnaires;
        }

        // GET: api/Questionnaires/5
        [ResponseType(typeof(Questionnaires))]
        public IHttpActionResult GetQuestionnaires(int id)
        {
            Questionnaires questionnaires = db.Questionnaires.Find(id);
            if (questionnaires == null)
            {
                return NotFound();
            }

            return Ok(questionnaires);
        }

        // PUT: api/Questionnaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaires(int id, Questionnaires questionnaires)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaires.Id)
            {
                return BadRequest();
            }

            db.Entry(questionnaires).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnairesExists(id))
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

        // POST: api/Questionnaires
        [ResponseType(typeof(Questionnaires))]
        public IHttpActionResult PostQuestionnaires(Questionnaires questionnaires)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questionnaires.Add(questionnaires);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionnairesExists(questionnaires.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionnaires.Id }, questionnaires);
        }

        // DELETE: api/Questionnaires/5
        [ResponseType(typeof(Questionnaires))]
        public IHttpActionResult DeleteQuestionnaires(int id)
        {
            Questionnaires questionnaires = db.Questionnaires.Find(id);
            if (questionnaires == null)
            {
                return NotFound();
            }

            db.Questionnaires.Remove(questionnaires);
            db.SaveChanges();

            return Ok(questionnaires);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnairesExists(int id)
        {
            return db.Questionnaires.Count(e => e.Id == id) > 0;
        }
    }
}