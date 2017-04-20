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
    public class Types_QuestionnaireController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Types_Questionnaire
        public IQueryable<Types_Questionnaire> GetTypes_Questionnaire()
        {
            return db.Types_Questionnaire;
        }

        // GET: api/Types_Questionnaire/5
        [ResponseType(typeof(Types_Questionnaire))]
        public IHttpActionResult GetTypes_Questionnaire(string id)
        {
            Types_Questionnaire types_Questionnaire = db.Types_Questionnaire.Find(id);
            if (types_Questionnaire == null)
            {
                return NotFound();
            }

            return Ok(types_Questionnaire);
        }

        // PUT: api/Types_Questionnaire/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypes_Questionnaire(string id, Types_Questionnaire types_Questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != types_Questionnaire.type)
            {
                return BadRequest();
            }

            db.Entry(types_Questionnaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Types_QuestionnaireExists(id))
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

        // POST: api/Types_Questionnaire
        [ResponseType(typeof(Types_Questionnaire))]
        public IHttpActionResult PostTypes_Questionnaire(Types_Questionnaire types_Questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Types_Questionnaire.Add(types_Questionnaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Types_QuestionnaireExists(types_Questionnaire.type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = types_Questionnaire.type }, types_Questionnaire);
        }

        // DELETE: api/Types_Questionnaire/5
        [ResponseType(typeof(Types_Questionnaire))]
        public IHttpActionResult DeleteTypes_Questionnaire(string id)
        {
            Types_Questionnaire types_Questionnaire = db.Types_Questionnaire.Find(id);
            if (types_Questionnaire == null)
            {
                return NotFound();
            }

            db.Types_Questionnaire.Remove(types_Questionnaire);
            db.SaveChanges();

            return Ok(types_Questionnaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Types_QuestionnaireExists(string id)
        {
            return db.Types_Questionnaire.Count(e => e.type == id) > 0;
        }
    }
}