using CinemaApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Models
{
    public class FilmEditView
    {
        public Film Film { get; set; }
        public List<Country> Countries { get; set; }
        public List<Janre> Janres { get; set; }
        public string[] FilmCounties { get; set; }
        public string[] FilmJanres { get; set; }
    }
}