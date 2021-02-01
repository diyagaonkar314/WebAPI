using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;

namespace HotelApplication.Controllers
{
    public class EmployeeController : ApiController
    {
        HotelDBEntities1 db = new HotelDBEntities1();

        public EmployeeController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return db.Employees.ToList();
        }


        // GET api/<controller>/5
        [HttpGet]
        public Employee GetById(string id)
        {
            return db.Employees.Find(id);
        }

        // POST api/<controller>

        [HttpPost]
        public HttpResponseMessage Post(Employee c1)
        {
            try
            {
                db.Employees.Add(c1);
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
        public HttpResponseMessage Put(int id, Employee c1)
        {
            try
            {
                if (id == c1.Eid)
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
                Employee c1 = db.Employees.Find(id);
                if (c1 != null)
                {
                    db.Employees.Remove(c1);
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