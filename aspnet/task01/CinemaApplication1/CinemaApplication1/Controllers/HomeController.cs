using CinemaApplication1.Entities;
using CinemaApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApplication1.Controllers
{
    public class HomeController : Controller
    { 
        

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateFilm(FilmCreateViewModel film)
        {            
            using (CinemaContext context = new CinemaContext())
            {
                List<Country> countries = new List<Country>();
                foreach (var item in film.Countries)
                {
                    countries.Add(context.Countries.Find(Convert.ToInt32(item)));
                }

                List<Janre> janres = new List<Janre>();
                foreach (var item in film.Janres)
                {
                    janres.Add(context.Janres.Find(Convert.ToInt32(item)));
                }


                Film newFilm = new Film
                {
                    Name = film.Name,
                    PublicationDate = film.PublicationDate,
                    Link = film.Link,
                    Duration = film.Duration,
                    Countries = countries,
                    Janres = janres
                };

                context.Films.Add(newFilm);
                context.SaveChanges();
            }

            TempData["film_success"] = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateCountry(Country country)
        {
            using (CinemaContext context = new CinemaContext())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }

            TempData["country_success"] = true;
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult CreateJanre(Janre janre)
        {
            using (CinemaContext context = new CinemaContext())
            {
                context.Janres.Add(janre);
                context.SaveChanges();
            }

            TempData["janre_success"] = true;
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public ActionResult Index()
        {
            FilmViewModel model = new FilmViewModel();
            using (CinemaContext context = new CinemaContext())
            {
                model.Films = context.Films.ToList();
                model.Countries = context.Countries.ToList();
                model.Janres = context.Janres.ToList();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Detail(int id)
        {
            using (CinemaContext context = new CinemaContext())
            {   

                var film = context.Films.Include("Janres").Include("Countries").FirstOrDefault(x => x.FilmID == id);
                return View(film);
            }
        }
    }
}