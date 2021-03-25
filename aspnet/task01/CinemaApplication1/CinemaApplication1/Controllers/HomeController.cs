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
                Film newFilm = new Film
                {
                    Name = film.Name,
                    PublicationDate = film.PublicationDate,
                    Link = film.Link,
                    Duration = film.Duration,
                };

                var createdFilm = context.Films.Add(newFilm);

                foreach (var country_id in film.Countries)
                {
                    var filmCountry = new FilmCountry
                    {
                        FilmId = createdFilm.ID,
                        CountryId = Convert.ToInt32(country_id)
                    };

                    context.FilmCountries.Add(filmCountry);
                }

                foreach (var janre_id in film.Janres)
                {
                    var filmJanre = new FilmJanre
                    {
                        FilmId = createdFilm.ID,
                        JanreId = Convert.ToInt32(janre_id)
                    };

                    context.FilmJanres.Add(filmJanre);
                }

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
        public ActionResult Index(FilmViewModel argData)
        {
            FilmViewModel model = new FilmViewModel();
            using (CinemaContext context = new CinemaContext())
            {
                if (argData.Start != null && argData.End != null) 
                {
                    model.Films = context.Films
                        .Where(x => x.PublicationDate >= argData.Start && x.PublicationDate <= argData.End).ToList();
                }
                else 
                {
                    model.Films = context.Films.ToList();
                    
                }
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
            DetailsViewModel details = null;
            using (CinemaContext context = new CinemaContext())
            {
                details = new DetailsViewModel
                {
                    Film = context.Films.Where(x => x.ID == id).FirstOrDefault(),
                    FilmCountries = context.FilmCountries.Include("Country").Where(x => x.FilmId == id).ToList(),
                    FilmJanres = context.FilmJanres.Include("Janre").Where(x => x.FilmId == id).ToList(),
                };
            }

            if (details == null) return HttpNotFound();
            else return View(details);

        }
    }
}