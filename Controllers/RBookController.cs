using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class RBookController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();


        // GET api/<controller>
        public RBookController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<RoomBook> Get()
        {
            return db.RoomBooks.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public RoomBook Get(int id)
        {
            return db.RoomBooks.Find(id);
        }

        [HttpGet]
        public IEnumerable<RoomBook> Get([FromUri] string Cid)
        {
            var rb = db.RoomBooks.Where(i => i.Cid == Cid);
            return rb;

        }

        [HttpGet]
        public IEnumerable<RoomBook> Get([FromUri] DateTime Dfrom)
        {
            var rb = db.RoomBooks.Where(i => i.Dfrom == Dfrom);
            return rb;

        }



        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(RoomBook c1)
        {
            try
            {
                db.RoomBooks.Add(c1);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5

        [HttpPut]
        public HttpResponseMessage Put(int id, RoomBook c1)
        {
            try
            {
                if (id == c1.RBookid)
                {
                    db.Entry(c1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<controller>/5

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                RoomBook c1 = db.RoomBooks.Find(id);
                if (c1 != null)
                {
                    db.RoomBooks.Remove(c1);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            }
        }
    }
}