using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.Models;
using HotelApplication.VM;

namespace HotelApplication.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        HotelDBEntities1 DB = new HotelDBEntities1();
        [Route("InsertCustomer")]
        [HttpPost]
        public object InsertCustomer(Register Reg)
        {
            try
            {

                Customer EL = new Customer();
                if (EL.Cid == "")
                {
                    EL.Cname = Reg.Cname;
                    EL.Cemail = Reg.Cemail;
                    EL.Cphone = Reg.Cphone;
                    EL.Ccity = Reg.Ccity;
                    EL.Cdob = Reg.Cdob;
                    EL.Cpincode = Reg.Cpincode;
                    EL.Cnation = Reg.Cnation;
                    EL.Cgen = Reg.Cgen;
                    EL.Cpass = Reg.Cpass;



                    DB.Customers.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(Login login)
        {
            var log = DB.Customers.Where(x => x.Cid.Equals(login.Cid) && x.Cpass.Equals(login.Cpass)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User."  };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully", userID = login.Cid};
        }
    }
}