using AlbumApplication.Models.Domain;
using AlbumApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumApplication.Controllers
{
    public class PersonController : Controller
    {
        DataBase db = new DataBase();

        public ActionResult Grid()
        {
            var list = db.Person.Select(person => new PersonGridViewModel()
            {
                Id = person.Id,
                Name = person.Name
            }).ToList();
            return View(list);
        }

        // GET: Person
        public ActionResult Create()
        {
            var viewModel = new PersonViewModel(db);
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var person = viewModel.ConvertToPerson(db);
                db.Person.Add(person);
                db.SaveChanges();

                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var person = db.Person.Find(id);
            var viewModel = new PersonViewModel().ConvertToPersonViewModel(person, db);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var person = db.Person.Find(viewModel.Id);
                person.Name = viewModel.Name;
                db.SaveChanges();

                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();

            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}