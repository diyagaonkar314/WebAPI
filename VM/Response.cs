using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplication.VM
{
    public class Response
    {
        internal string userID;

        public string Status { set; get; }
        public string Message { set; get; }
    }
}