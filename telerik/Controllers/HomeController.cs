using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using telerik.Infrastructure;
using telerik.Models;

namespace telerik.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        PeopleRepository _repo = new PeopleRepository();

        public ActionResult Index()
        {
            return View();
        }

        [GridAction]
        public ActionResult GetPeople()
        {
            return View(new GridModel(_repo.GetAllPeople()));
        }

        [GridAction]
        public ActionResult EditPerson(int id)
        {
            var person = _repo.Find(id);
            UpdateModel(person);
            return GetPeople();
        }

        [GridAction]
        public ActionResult AddPerson(Person person)
        {
            _repo.Add(person);
            return GetPeople();
        }

        [GridAction]
        public ActionResult DeletePerson(int id)
        {
            _repo.RemoveById(id);
            return GetPeople();
        }
    }
}
