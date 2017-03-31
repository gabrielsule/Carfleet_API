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
    public class DeviceModelsController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        // GET: api/DeviceModels
        public IQueryable<DeviceModel> GetDeviceModels()
        {
            return db.DeviceModels;
        }

        // GET: api/DeviceModels/5
        [ResponseType(typeof(DeviceModel))]
        public IHttpActionResult GetDeviceModel(int id)
        {
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return NotFound();
            }

            return Ok(deviceModel);
        }

        [HttpGet]

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceModelExists(int id)
        {
            return db.DeviceModels.Count(e => e.id == id) > 0;
        }
    }
}