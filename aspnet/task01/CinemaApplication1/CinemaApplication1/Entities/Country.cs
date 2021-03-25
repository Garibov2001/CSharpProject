using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class Country
    {
        public Country()
        {
            FilmCountries = new HashSet<FilmCountry>();
        }
        [Key]
        public int ID { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public virtual ICollection<FilmCountry> FilmCountries { get; set; }

    }
}