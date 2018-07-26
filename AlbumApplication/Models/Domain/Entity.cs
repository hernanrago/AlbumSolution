using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumApplication.Models.Domain
{
    public class Entity
    {
        [ScaffoldColumn(false)]
        private Guid guid { get; set; }
        //private Guid guid = default(Guid);

        [Key]
        public Guid Id
        {
            get
            {
                if (this.guid == default(Guid) || this.guid == null)
                    this.guid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd);
                return guid;
            }

            set { this.guid = value; }
        }
    }
}