using System.Collections.Generic;

namespace AlbumApplication.Models.Domain
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public virtual List<Artist> Artists { get; set;  }
    }
}