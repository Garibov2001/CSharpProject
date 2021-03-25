using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class Film
    {
        public Film()
        {
            FilmCountries = new HashSet<FilmCountry>();
            FilmJanres = new HashSet<FilmJanre>();
        }
        [Key]
        public int ID { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }

        public virtual ICollection<FilmCountry> FilmCountries { get; set; }
        public virtual ICollection<FilmJanre> FilmJanres { get; set; }
    }
}