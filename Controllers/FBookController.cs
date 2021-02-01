using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class FBookController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();
        // GET api/<controller>

        public FBookController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<FoodBook> Get()
        {
            return db.FoodBooks.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public FoodBook GetById(string id)
        {
            return db.FoodBooks.Find(id);
        }

        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(FoodBook c1)
        {
            try
            {
                db.FoodBooks.Add(c1);
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
        public HttpResponseMessage Put(int id, FoodBook c1)
        {
            try
            {
                if (id == c1.FBookid)
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
                FoodBook c1 = db.FoodBooks.Find(id);
                if (c1 != null)
                {
                    db.FoodBooks.Remove(c1);
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