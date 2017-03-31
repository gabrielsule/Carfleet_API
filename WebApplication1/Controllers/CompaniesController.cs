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
    public class CompaniesController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class model{
            public int id { get; set; }
            public int companyType { get; set; }
            public int company { get; set; }
            public string name { get; set; }
            public string cif { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string fax { get; set; }
            public string email { get; set; }
            public string registry { get; set; }
        }

        [HttpGet]
        [Route("api/Companies")]
        public IQueryable<Company> GetCompanies()
        {
            return db.Companies;
        }

        [HttpGet]
        [Route("api/Companies/{Id}")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        [Route("api/Companies/Update")]
        public HttpResponseMessage updateCompany(model data)
        {

            db.sp_CompanyUpdate(data.id, data.name, data.companyType, data.cif, data.address, data.phone, data.fax, data.email, data.registry);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [HttpPost]
        [Route("api/Companies/Insert")]
        public HttpResponseMessage insertCompany(model data)
        {

            db.sp_CompanyInsert(data.name, data.companyType, data.company, data.cif, data.address, data.phone, data.fax, data.email, data.registry);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [HttpDelete]
        [Route("api/Companies/{Id}")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.id == id) > 0;
        }
    }
}