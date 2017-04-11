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
    public class Options_QuestionnaireController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Options_Questionnaire
        public IQueryable<Options_Questionnaire> GetOptions_Questionnaire()
        {
            return db.Options_Questionnaire;
        }

        // GET: api/Options_Questionnaire/5
        [ResponseType(typeof(Options_Questionnaire))]
        public IHttpActionResult GetOptions_Questionnaire(int id)
        {
            Options_Questionnaire options_Questionnaire = db.Options_Questionnaire.Find(id);
            if (options_Questionnaire == null)
            {
                return NotFound();
            }

            return Ok(options_Questionnaire);
        }

        // PUT: api/Options_Questionnaire/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOptions_Questionnaire(int id, Options_Questionnaire options_Questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != options_Questionnaire.Id)
            {
                return BadRequest();
            }

            db.Entry(options_Questionnaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Options_QuestionnaireExists(id))
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

        // POST: api/Options_Questionnaire
        [ResponseType(typeof(Options_Questionnaire))]
        public IHttpActionResult PostOptions_Questionnaire(Options_Questionnaire options_Questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Options_Questionnaire.Add(options_Questionnaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Options_QuestionnaireExists(options_Questionnaire.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = options_Questionnaire.Id }, options_Questionnaire);
        }

        // DELETE: api/Options_Questionnaire/5
        [ResponseType(typeof(Options_Questionnaire))]
        public IHttpActionResult DeleteOptions_Questionnaire(int id)
        {
            Options_Questionnaire options_Questionnaire = db.Options_Questionnaire.Find(id);
            if (options_Questionnaire == null)
            {
                return NotFound();
            }

            db.Options_Questionnaire.Remove(options_Questionnaire);
            db.SaveChanges();

            return Ok(options_Questionnaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Options_QuestionnaireExists(int id)
        {
            return db.Options_Questionnaire.Count(e => e.Id == id) > 0;
        }
    }
}