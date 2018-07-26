using AlbumApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.ViewModels
{
    public class AlbumViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int NumberOfTracks { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual List<SelectViewModel> ArtistList { get; set; }
        public Guid SelectedArtistId { get; set; }

        public AlbumViewModel()
        {
        }

        public AlbumViewModel(DataBase db)
        {
            ArtistList = db.Artist.Select(a => new SelectViewModel { Id = a.Id, Name = a.Name }).ToList();
        }

        public Album ConvertToAlbum(DataBase db)
        {
            var album = new Album()
            {
                Id = Id,
                Name = Name,
                Artist = db.Artist.Find(SelectedArtistId),
                NumberOfTracks = NumberOfTracks,
                ReleaseDate = ReleaseDate
            };
            return album;
        }

        public AlbumViewModel ConvertToAlbumViewModel(Album album, DataBase db)
        {
            var viewModel = new AlbumViewModel(db)
            {
                Id = album.Id,
                Name = album.Name,
                Artist = album.Artist,
                NumberOfTracks = album.NumberOfTracks,
                ReleaseDate = album.ReleaseDate
            };
            return viewModel;
        }

    }
}