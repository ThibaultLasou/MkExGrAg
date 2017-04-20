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
    public class MessagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Messages
        public IQueryable<Messages> GetMessages()
        {
            return db.Messages;
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Messages))]
        public IHttpActionResult GetMessages(int id)
        {
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMessages(int id, Messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messages.Id)
            {
                return BadRequest();
            }

            db.Entry(messages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagesExists(id))
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

        // POST: api/Messages
        [ResponseType(typeof(Messages))]
        public IHttpActionResult PostMessages(Messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(messages);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MessagesExists(messages.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = messages.Id }, messages);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Messages))]
        public IHttpActionResult DeleteMessages(int id)
        {
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return NotFound();
            }

            db.Messages.Remove(messages);
            db.SaveChanges();

            return Ok(messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessagesExists(int id)
        {
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}