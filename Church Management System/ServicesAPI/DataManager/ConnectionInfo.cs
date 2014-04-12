using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesAPI.DataManager
{
    public class ConnectionInfo
    {
        public String server { get; set; } 
        public String database { get; set; }  
        public String UserId { get; set; }
        public String Password { get; set; }
    }
}