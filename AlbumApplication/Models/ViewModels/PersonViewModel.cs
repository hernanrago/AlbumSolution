using AlbumApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.ViewModels
{
    public class PersonViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public virtual List<Artist> Artists { get; set; }

        public PersonViewModel()
        {
        }

        public PersonViewModel(DataBase db)
        {
            Artists = db.Artist.ToList();
        }

        public Person ConvertToPerson(DataBase db)
        {
            var person = new Person()
            {
                Id = Id,
                Name = Name,
                Artists = db.Artist.ToList()
            };
            return person;
        }

        public PersonViewModel ConvertToPersonViewModel(Person person, DataBase db)
        {
            var viewModel = new PersonViewModel(db)
            {
                Id = person.Id,
                Name = person.Name,
                Artists = person.Artists
            };
            return viewModel;
        }
    }
}