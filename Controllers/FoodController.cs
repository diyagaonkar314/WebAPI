using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class FoodController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();


        public FoodController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return db.Foods.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public Food GetById(int id)
        {
            return db.Foods.Find(id);
        }

        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(Food c1)
        {
            try
            {
                db.Foods.Add(c1);
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
        public HttpResponseMessage Put(int id, Food c1)
        {
            try
            {
                if (id == c1.Fid)
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
                Food c1 = db.Foods.Find(id);
                if (c1 != null)
                {
                    db.Foods.Remove(c1);
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