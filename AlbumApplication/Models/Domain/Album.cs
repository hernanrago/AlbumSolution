using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.Domain
{
    public class Album : Entity
    {
        public string Name { get; set; }
        public virtual Artist Artist { get; set; }
        public int NumberOfTracks { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}