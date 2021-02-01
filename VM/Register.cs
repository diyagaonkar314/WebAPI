using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication.VM
{
    public class Register
    {
        public string Cid { get; set; }
        public string Cname { get; set; }
        public string Cemail { get; set; }
        public long Cphone { get; set; }
        public string Ccity { get; set; }

        public DateTime Cdob { get; set; }
        public int Cpincode {get;set;}
        public string Cnation { get; set; }
        public string  Cgen { get; set; }
        public string Cpass { get; set; }
    }
}