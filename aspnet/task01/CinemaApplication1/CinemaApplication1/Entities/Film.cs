using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class Film
    {
        public Film()
        {
            this.Janres = new HashSet<Janre>();
            this.Countries = new HashSet<Country>();
        }
        public int FilmID { get; set; }
        public string Name { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
        public virtual ICollection<Janre> Janres { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}