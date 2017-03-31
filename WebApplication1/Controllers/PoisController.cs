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
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class PoisController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        // GET: api/Pois
        public IQueryable<Poi> GetPois()
        {
            return db.Pois;
        }

        // GET: api/Pois/5
        [ResponseType(typeof(Poi))]
        public IHttpActionResult GetPoi(int id)
        {
            Poi poi = db.Pois.Find(id);
            if (poi == null)
            {
                return NotFound();
            }

            return Ok(poi);
        }

        // PUT: api/Pois/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoi(int id, Poi poi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poi.id)
            {
                return BadRequest();
            }

            db.Entry(poi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoiExists(id))
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

        // POST: api/Pois
        [ResponseType(typeof(Poi))]
        public IHttpActionResult PostPoi(Poi poi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pois.Add(poi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poi.id }, poi);
        }

        // DELETE: api/Pois/5
        [ResponseType(typeof(Poi))]
        public IHttpActionResult DeletePoi(int id)
        {
            Poi poi = db.Pois.Find(id);
            if (poi == null)
            {
                return NotFound();
            }

            db.Pois.Remove(poi);
            db.SaveChanges();

            return Ok(poi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoiExists(int id)
        {
            return db.Pois.Count(e => e.id == id) > 0;
        }
    }
}