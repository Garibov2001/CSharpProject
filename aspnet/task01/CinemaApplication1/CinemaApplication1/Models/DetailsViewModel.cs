using CinemaApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Models
{
    public class DetailsViewModel
    {
        public List<FilmJanre> FilmJanres { get; set; }
        public List<FilmCountry> FilmCountries { get; set; }
        public Film Film { get; set; }
    }
}