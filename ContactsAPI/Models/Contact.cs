using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactsAPI.Models;

namespace ContactsAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public name name { get; set; }
        public address address { get; set; }
        public phone[] phone { get; set; }
        public string email { get; set; }
    }
}