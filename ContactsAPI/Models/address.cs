using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;

namespace ContactsAPI.Models
{
    public class address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

    }
}