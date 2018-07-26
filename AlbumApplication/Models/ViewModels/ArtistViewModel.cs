using AlbumApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.ViewModels
{
    public class ArtistViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public virtual List<Person> Members { get; set; }
        public virtual List<Album> Albums { get; set; }

        public ArtistViewModel()
        {
        }

        public ArtistViewModel(DataBase db)
        {
            Members = db.Person.ToList();
            Albums = db.Album.ToList();
        }

        public Artist ConvertToArtist(DataBase db)
        {
            var artist = new Artist()
            {
                Id = Id,
                Name = Name,
                Members = db.Person.ToList(),
                Albums = db.Album.ToList()

            };
            return artist;
        }

        public ArtistViewModel ConvertToArtistViewModel(Artist artist, DataBase db)
        {
            var viewModel = new ArtistViewModel(db)
            {
                Id = artist.Id,
                Name = artist.Name,
                Members = artist.Members,
                Albums = artist.Albums
            };
            return viewModel;
        }
    }
}