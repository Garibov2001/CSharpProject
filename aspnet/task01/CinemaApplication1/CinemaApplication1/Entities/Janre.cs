using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class Janre
    {
        public Janre()
        {
            this.Films = new HashSet<Film>();            
        }
        public int JanreID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}