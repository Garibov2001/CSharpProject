using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class FilmCountry
    {
        public int FilmId { get; set; }
        public int CountryId { get; set; }
        public virtual Film Film { get; set; }
        public virtual Country Country { get; set; }
    }
}