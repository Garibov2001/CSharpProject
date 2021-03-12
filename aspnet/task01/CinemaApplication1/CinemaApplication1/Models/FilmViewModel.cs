using CinemaApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Models
{
    public class FilmViewModel
    {
        public List<Film> Films { get; set; }
        public List<Country> Countries { get; set; }
        public List<Janre> Janres { get; set; }
    }
}