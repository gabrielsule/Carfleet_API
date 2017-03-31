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
    public class FleetsController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class modelFleet {
            public int id { get; set; }
            public int id_company { get; set; }
            public string name { get; set; }
        }

        // GET: api/Fleets
        public IQueryable<Fleet> GetFleets()
        {
            return db.Fleets;
        }

        // GET: api/Fleets/5
        [ResponseType(typeof(Fleet))]
        public IHttpActionResult GetFleet(int id)
        {
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return NotFound();
            }
            
            return Ok(fleet);
        }

        [HttpPut]
        [Route("api/Fleets/Update")]
        public HttpResponseMessage updateFleet(modelFleet data)
        {

            db.sp_FleetUpdate(data.id, data.id_company, data.name);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Fleets/Insert")]
        public HttpResponseMessage insertFleet(modelFleet data)
        {

            db.sp_FleetInsert(data.id_company, data.name);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        // DELETE: api/Fleets/5
        [ResponseType(typeof(Fleet))]
        public IHttpActionResult DeleteFleet(int id)
        {
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return NotFound();
            }

            db.Fleets.Remove(fleet);
            db.SaveChanges();

            return Ok(fleet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FleetExists(int id)
        {
            return db.Fleets.Count(e => e.id == id) > 0;
        }
    }
}