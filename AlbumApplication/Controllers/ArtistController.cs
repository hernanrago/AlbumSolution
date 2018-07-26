using AlbumApplication.Models.Domain;
using AlbumApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumApplication.Controllers
{
    public class ArtistController : Controller
    {
        DataBase db = new DataBase();

        public ActionResult Grid()
        {
            var list = db.Artist.Select(artist => new ArtistGridViewModel()
            {
                Id = artist.Id,
                Name = artist.Name
            }).ToList();
            return View(list);
        }

        // GET: Artist
        public ActionResult Create()
        {
            //var viewModel = new ArtistViewModel(db);
            var viewModel = new ArtistViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArtistViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var artist = viewModel.ConvertToArtist(db);
                db.Artist.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var artist = db.Artist.Find(id);
            var viewModel = new ArtistViewModel().ConvertToArtistViewModel(artist, db);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var artist = db.Artist.Find(viewModel.Id);
                artist.Name = viewModel.Name;
                db.SaveChanges();

                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var artist = db.Artist.Find(id);
            try { 
            db.Artist.Remove(artist);
            db.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { Result = "Error", Mensaje = "Este artista tiene albumes que dependen del mismo." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}