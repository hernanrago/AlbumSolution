using AlbumApplication.Models.Domain;
using AlbumApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumApplication.Controllers
{
    public class AlbumController : Controller
    {
        DataBase db = new DataBase();

        public ActionResult Grid()
        {
            var list = db.Album.Select(album => new AlbumGridViewModel()
            {
                Id = album.Id,
                Name = album.Name
            }).ToList();
            return View(list);
        }

        // GET: Album
        public ActionResult Create()
        {
            var model = new AlbumViewModel(db);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = viewModel.ConvertToAlbum(db);
                db.Album.Add(album);
                db.SaveChanges();

                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var album = db.Album.Find(id);
            var model = new AlbumViewModel(db).ConvertToAlbumViewModel(album, db);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = db.Album.Find(viewModel.Id);
                album.Name = viewModel.Name;
                if (album.Artist.Id != viewModel.SelectedArtistId)
                    album.Artist = db.Artist.Find(viewModel.SelectedArtistId);
                album.NumberOfTracks = viewModel.NumberOfTracks;
                album.ReleaseDate = viewModel.ReleaseDate;
                db.SaveChanges();

                return RedirectToAction("Grid");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var album = db.Album.Find(id);
            db.Album.Remove(album);
            db.SaveChanges();

            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}