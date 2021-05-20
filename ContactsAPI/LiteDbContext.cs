using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;

namespace ContactsAPI
{
    public class LiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext()
        {
            Database = new LiteDatabase(@"C:\\Temp\\MyData.db");
        }
    }
}