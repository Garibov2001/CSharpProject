using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class FilmJanre
    {
        public int FilmId { get; set; }
        public int JanreId { get; set; }
        public virtual Film Film { get; set; }
        public virtual Janre Janre { get; set; }
    }
}