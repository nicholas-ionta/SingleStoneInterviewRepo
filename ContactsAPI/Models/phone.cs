using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;

namespace ContactsAPI.Models
{
    public class phone
    {
        public string number { get; set; }
        public string type { get; set; }

    }
}