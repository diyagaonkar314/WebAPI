using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class RoomController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();
        // GET api/<controller>

        public RoomController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return db.Rooms.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public Room GetById(int id)
        {
            return db.Rooms.Find(id);
        }

        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(Room c1)
        {
            try
            {
                db.Rooms.Add(c1);
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
        public HttpResponseMessage Put(int id, Room c1)
        {
            try
            {
                if (id == c1.Rid)
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
                Room c1 = db.Rooms.Find(id);
                if (c1 != null)
                {
                    db.Rooms.Remove(c1);
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