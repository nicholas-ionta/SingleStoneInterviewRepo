using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsAPI.Models;
using Newtonsoft.Json;
using LiteDB;

namespace ContactsAPI.Controllers
{
    public class ContactController : ApiController
    {
        //IEnumerable<Contact> contacts = new Contact[]
        //{
        //    new Contact {Id = 1, name = {first = "Nick", middle = "James", last = "Ionta"}, address = { street = "Name of Street", city = "Baltimore", state = "MD", zip = "21xxx" } , phone = { number = "336-314-0032", type = "mobile" }, email = "nick.ionta@gmail.com" },
        //    new Contact {Id = 2, name = {first = "Bacon", middle = "", last = "Crispy"}, address = { street = "Name of Street", city = "Baltimore", state = "MD", zip = "21xxx" } , phone = { number = "704-324-6548", type = "home" }, email = "yadda@yadda.com" },
        //    new Contact {Id = 3, name = {first = "Tuna", middle = "Seared", last = "Juicy"}, address = { street = "Name of Street", city = "Baltimore", state = "MD", zip = "21xxx" } , phone = { number = "708-654-1325", type = "work" }, email = "yadda2@yadda.com" },
        //};

        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult GetAllContacts()
        {
            Object returnVals = null;
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");

                    returnVals = Contacts.FindAll().ToList();
                }
            }catch (Exception e)
            {

            }

            return Json(returnVals);
        }

        [HttpGet]
        [ActionName("Get")]
        public IHttpActionResult GetContact(int Id)
        {
            Object returnVals = null;
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");

                    Contacts.EnsureIndex(x => x.Id);

                    returnVals = Contacts.FindById(Id);
                }
            }
            catch (Exception e)
            {

            }

            return Json(returnVals);
        }

        [HttpPost]
        [ActionName("create")]
        public IHttpActionResult CreateContact(Contact contact)
        {
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");
                    Contacts.Insert(contact);
                }
            }
            catch (Exception e)
            {

            }
            return Json(contact);
        }


        /*In the documentation for the PUT "Update a contact" the uri saId it would be by Id "/contacts/{Id}" however in #2 the JSON dId not contain an option for the Id field being passed back so I am making an assumption that 
         * there will be an Id in the JSON payload to determine which contact is which. 
         */
        [HttpPut]
        [ActionName("update")]
        public IHttpActionResult UpdateContact(Contact contact)
        {
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");
                    Contacts.Update(contact);
                }
            }
            catch (Exception e)
            {

            }
            return Json(contact);
        }

        [HttpDelete]
        [ActionName("delete")]
        public IHttpActionResult DeleteContact(int Id)
        {
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");
                    Contacts.EnsureIndex(x => x.Id);
                    var delContact = Contacts.FindById(Id);

                    Contacts.Delete(1);
                }
            }
            catch (Exception e)
            {

            }
            return Json(GetAllContacts());
        }

        [HttpGet]
        [ActionName("call-list")]
        public IHttpActionResult ContactCallList()
        {
            Object returnVals = null;
            try
            {
                using (var db = new LiteDatabase(@"C:\\Temp\\MyData.db"))
                {
                    var Contacts = db.GetCollection<Contact>("Contacts");

                    Contacts.EnsureIndex(x => x.name.last);
                    Contacts.EnsureIndex(x => x.phone);

                    returnVals = Contacts.FindAll()
                                .OrderBy(x => x.name.last)
                                .OrderBy(x => x.name.first)
                                .Select(x => new {
                                    name = new name { first = x.name.first, middle = x.name.middle, last = x.name.last },
                                    phone = x.phone
                                }).Where(x => x.phone != null && x.phone.Any(z => z.type == "home"))
                                .ToList();
                }
            }
            catch (Exception e)
            {

            }

            return Json(returnVals);
        }
    }
}
