using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class CustomerController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();
        // GET api/<controller>

        public CustomerController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public Customer GetById(string id)
        {
            return db.Customers.Find(id);
        }

        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(Customer c1)
        {
            try
            {
                db.Customers.Add(c1);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5

        [HttpPut]
        public HttpResponseMessage Put(string id, Customer c1)
        {
            try
            {
                if(id==c1.Cid)
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
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<controller>/5

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                Customer c1 = db.Customers.Find(id);
                if(c1!=null)
                {
                    db.Customers.Remove(c1);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

                }
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            }
        }
    }
}