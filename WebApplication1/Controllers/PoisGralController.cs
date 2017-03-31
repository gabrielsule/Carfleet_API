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
    public class PoisGralController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class ModelPoiGral
        {
            public int id_company { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public float lat { get; set; }
            public float lng { get; set; }
            public int rad { get; set; }
            public int type { get; set; }
        }

        [HttpGet]
        [Route("api/Poi")]
        public IQueryable<Poi> GetPois()
        {
            return db.Pois;
        }

        [HttpGet]
        [Route("api/Poi/Types")]
        public IQueryable<PoiType> GetPoisType()
        {
            return db.PoiTypes;
        }

        [HttpPut]
        [Route("api/Poi/Update")]
        public HttpResponseMessage sp_PoiUpdate(ModelPoiGral data)
        {

            db.sp_PoiUpdate(data.id, data.name, data.lat, data.lng, data.rad, data.type);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Poi/Insert")]
        public HttpResponseMessage insertVehicle(ModelPoiGral data)
        {

            db.sp_PoiInsert(data.id_company, data.name, data.lat, data.lng, data.rad, data.type);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [HttpDelete]
        [Route("api/Poi/Delete/{id}")]
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