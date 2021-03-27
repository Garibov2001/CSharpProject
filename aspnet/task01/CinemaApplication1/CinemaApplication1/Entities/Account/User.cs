using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities.Account
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }



    }
}