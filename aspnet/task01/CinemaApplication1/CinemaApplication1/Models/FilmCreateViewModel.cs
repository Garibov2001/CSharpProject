using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Models
{
    public class FilmCreateViewModel
    {
        public int FilmID { get; set; }
        public string Name { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
        public string[] Janres { get; set; }
        public string[] Countries { get; set; }
    }
}