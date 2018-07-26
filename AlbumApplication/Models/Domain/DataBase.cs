using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.Domain
{
    public class DataBase : DbContext
    {
        public DataBase() : base("DefaultConnection")
        {

        }


        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Person> Person { get; set; }
        
    }

  
}