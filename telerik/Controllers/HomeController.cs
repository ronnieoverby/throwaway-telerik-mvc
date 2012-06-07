using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using telerik.Models;

namespace telerik.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/


        public ActionResult Index()
        {
            return View();
        }

        private static List<Person> _people;
        private IEnumerable<Person> GetPeopleQuery()
        {
            return _people ?? (_people =
                               Enumerable.Range(1, 100)
                                   .Select(x => new Person
                                                    {
                                                        Id = x,
                                                        FirstName = "First " + x,
                                                        LastName = "last " + x,
                                                        Phone = "123-456-7890",
                                                        Email = "adsf@adsf.com"
                                                    }).ToList());
        }

        [GridAction]
        public ActionResult GetPeople()
        {
            return View(new GridModel(GetPeopleQuery()));
        }

        [GridAction]
        public ActionResult EditPerson(int id)
        {
            var person = _people.Single(x => x.Id == id);
            UpdateModel(person);
            return GetPeople();
        }

        [GridAction]
        public ActionResult AddPerson(Person person)
        {
            person.Id = _people.Max(x => x.Id) + 1;
            _people.Add(person);
            return GetPeople();
        }

        [GridAction]
        public ActionResult DeletePerson(int id)
        {
            var person = _people.Single(x => x.Id == id);
            _people.Remove(person);
            return GetPeople();
        }
    }
}
