using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.Domain
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public virtual List<Person> Members { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}