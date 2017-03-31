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
    public class DriversGralController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class modelDriver
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public int id_company { get; set; }
            public string personal_id { get; set; }
            public string phone_number { get; set; }
        }

        [HttpGet]
        [Route("api/Driver")]
        public IQueryable<Driver> GetDrivers()
        {
            return db.Drivers;
        }

        [HttpPut]
        [Route("api/Driver/Update")]
        public HttpResponseMessage sp_DriverUpdate(modelDriver data)
        {

            db.sp_DriverUpdate(data.id, data.name, data.surname, data.id_company, data.personal_id, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Driver/Insert")]
        public HttpResponseMessage sp_DriverInsert(modelDriver data)
        {

            db.sp_DriverInsert(data.name, data.surname, data.id_company, data.personal_id, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [HttpDelete]
        [Route("api/Driver/Delete/{id}")]
        [ResponseType(typeof(Driver))]
        public IHttpActionResult DeleteDriver(int id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            db.Drivers.Remove(driver);
            db.SaveChanges();

            return Ok(driver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverExists(int id)
        {
            return db.Drivers.Count(e => e.id == id) > 0;
        }
    }
}