using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesAPI.Model
{
    public class JsonCRUD
    {
        public int code { get; set; }
        public List<Dictionary<string, object>> data { get; set; }
        public Debug debug { get; set; }
    }
}