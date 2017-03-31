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
    public class UsersController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class modelUser{
        public int id { get; set; }
        public int id_usertype { get; set; }
        public int id_company { get; set; }
        public int id_language { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }

        public class modelUserFleet
        {
            public int id { get; set; }
            public int id_user { get; set; }
            public int id_fleet { get; set; }
            public string name { get; set; }
        }

        public class userFleet
        {
            public int id { get; set; } 
            public string login { get; set; }
            public string name { get; set; }
            public string password { get; set; }
        }

        public class userLoginApp
        {
            public string name { get; set; }
            public string password { get; set; }
        }

        [HttpGet]
        [Route("api/Users")]
        public IEnumerable<userFleet> GetUsers()
        {

           var temp = (from u in db.Users
                        select new 
                        {
                            id = u.id,
                            login = u.login,
                            name = u.name,
                            password = u.password
                        }).ToList();
            var result = temp.AsEnumerable().Select(t => new userFleet
            {
                id = t.id,
                login = t.login,
                name = t.name,
                password = util.Utils.Decrypt(t.password)
            });

            return result;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/UsersFleet")]
        public IEnumerable<sp_UserFleetSelect_Result> GetUserFleet(int id_user)
        {
 
            return db.sp_UserFleetSelect(id_user).AsEnumerable();
        }

        [HttpGet]
        [Route("api/Users/Login")]
        public IEnumerable<sp_UserLoginApp_Result> GetUserLogin(string name, string password)
        {
            string pwd = util.Utils.Encrypt(password);
            return db.sp_UserLoginApp(name, pwd).AsEnumerable();
        }

        [HttpPut]
        [Route("api/Users/Update")]
        public HttpResponseMessage updateUsers(modelUser data)
        {
             db.sp_UserUpdate(data.id, data.id_usertype, data.id_language, data.name, data.login, util.Utils.Encrypt(data.password));
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Users/Insert")]
        public HttpResponseMessage insertUser(modelUser data)
        {
            db.sp_UserInsert(data.id_usertype, data.id_company, data.id_language, data.name, data.login, util.Utils.Encrypt(data.password));
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("api/UsersFleet/Update")]
        public HttpResponseMessage updateUsersFleet(List<modelUserFleet> data)
        {
            foreach (var item in data)
            {
                db.sp_UserFleetDelete(item.id_user);
                db.SaveChanges();
            }

            foreach (var item in data)
            {
                db.sp_UserFleetUpdate(item.id, item.id_user, item.id_fleet);
                db.SaveChanges();
            }
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/UsersFleet/Insert")]
        public HttpResponseMessage insertUserFleet(List<modelUserFleet> data)
        {
            foreach (var item in data)
            {
                db.sp_UserFleetInsert(item.id_fleet);
                db.SaveChanges();
            }
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            db.sp_UserFleetDelete(id);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }

        //public sealed class Encryptor<T> where T : IBlockCipher, new()
        //{
        //    private readonly System.Text.Encoding encoding;

        //    private readonly IBlockCipher blockCipher;

        //    private BufferedBlockCipher cipher;

        //    private ICipherParameters parameters;

        //    public Encryptor(Encoding encoding, byte[] key)
        //    {
        //        this.blockCipher = new CbcBlockCipher(new T());
        //        this.parameters = new KeyParameter(key);
        //        this.cipher = new BufferedBlockCipher(this.blockCipher);
        //        this.encoding = encoding;
        //    }

        //    public Encryptor(Encoding encoding, byte[] key, byte[] iv)
        //    {
        //        this.blockCipher = new CbcBlockCipher(new T());
        //        this.parameters = new ParametersWithIV(new KeyParameter(key), iv);
        //        this.cipher = new BufferedBlockCipher(this.blockCipher);
        //        this.encoding = encoding;
        //    }

        //    public string Encrypt(string plain)
        //    {
        //        try
        //        {
        //            byte[] input = this.encoding.GetBytes(plain);

        //            if ((input.Length % this.blockCipher.GetBlockSize()) > 0)
        //            {
        //                byte[] newResult = new byte[(input.Length + (this.blockCipher.GetBlockSize() - (input.Length % this.blockCipher.GetBlockSize())))];
        //                input.CopyTo(newResult, 0);
        //                input = newResult;
        //            }

        //            byte[] result = this.BouncyCastleCrypto(true, input);

        //            return Convert.ToBase64String(result);
        //        }

        //        catch (CryptoException)
        //        {
        //            throw;
        //        }
        //    }

        //    public string Decrypt(string cipher)
        //    {
        //        try
        //        {
        //            byte[] result = this.BouncyCastleCrypto(false, Convert.FromBase64String(cipher));
        //            return this.encoding.GetString(result);
        //        }
        //        catch (CryptoException)
        //        {
        //            throw;
        //        }
        //    }

        //    private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input)
        //    {
        //        try
        //        {
        //            this.cipher.Init(forEncrypt, this.parameters);

        //            return this.cipher.DoFinal(input);
        //        }
        //        catch (CryptoException)
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}