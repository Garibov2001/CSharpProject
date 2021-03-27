using CinemaApplication1.Entities;
using CinemaApplication1.Entities.Account;
using CinemaApplication1.Filters;
using CinemaApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApplication1.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {
        private CinemaContext _context = new CinemaContext();

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateFilm(FilmCreateViewModel film)
        {                        
            Film newFilm = new Film
            {
                Name = film.Name,
                PublicationDate = film.PublicationDate,
                Link = film.Link,
                Duration = film.Duration,
                User = Session["user"] as User,
            };

            var createdFilm = _context.Films.Add(newFilm);

            foreach (var country_id in film.Countries)
            {
                var filmCountry = new FilmCountry
                {
                    FilmId = createdFilm.ID,
                    CountryId = Convert.ToInt32(country_id)
                };

                _context.FilmCountries.Add(filmCountry);
            }

            foreach (var janre_id in film.Janres)
            {
                var filmJanre = new FilmJanre
                {
                    FilmId = createdFilm.ID,
                    JanreId = Convert.ToInt32(janre_id)
                };

                _context.FilmJanres.Add(filmJanre);
            }

            _context.SaveChanges();
            

            TempData["success"] = "Film ugurla yaradildi.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateCountry(Country country)
        {
 
            _context.Countries.Add(country);
            _context.SaveChanges();

            TempData["success"] = "Seher ugurla yaradildi.";
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult CreateJanre(Janre janre)
        {
            _context.Janres.Add(janre);
            _context.SaveChanges();            

            TempData["success"] = "Janr ugurla yaradildi.";
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public ActionResult Index(FilmViewModel argData, string order_by = null)
        {
            FilmViewModel model = new FilmViewModel();

            if (argData.Start != null && argData.End != null) 
            {
                model.Films = _context.Films
                    .Where(x => x.PublicationDate >= argData.Start && x.PublicationDate <= argData.End).ToList();
                model.Start = argData.Start;
                model.End = argData.End;
            }
            else 
            {
                model.Films = _context.Films.ToList();
            }

            //Filtering options

            if (order_by == "name")
            {
                model.Films = model.Films.OrderBy(x => x.Name).ToList();
            }
            else if (order_by == "date")
            {
                model.Films = _context.Films.OrderBy(x => x.PublicationDate).ToList();
            }

            model.Countries = _context.Countries.ToList();
            model.Janres = _context.Janres.ToList();
            

            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Film film = _context.Films.FirstOrDefault(x => x.ID == id);

            if (film == null)
            {
                return HttpNotFound();
            }


            FilmEditView edit_view = new FilmEditView
            {
                Film = film,
                Countries = _context.Countries.ToList(),
                Janres = _context.Janres.ToList()
            };


            return View(edit_view);
        }

        [HttpPost]
        public ActionResult Edit(FilmEditView user_data)
        {
            Film edit_film = new Film
            {
                ID = user_data.Film.ID,
                Name = user_data.Film.Name,
                PublicationDate = user_data.Film.PublicationDate,
                Link = user_data.Film.Link,
                Duration = user_data.Film.Duration
            };

            _context.Entry(edit_film).State = System.Data.Entity.EntityState.Modified;

            // Remove all related filmcountry
            _context.FilmCountries.Where(m => m.FilmId == edit_film.ID)
                .ToList().ForEach(country => { _context.FilmCountries.Remove(country); _context.SaveChanges(); });

            // Remove all related filmjanres
            _context.FilmJanres.Where(m => m.FilmId == edit_film.ID)
                .ToList().ForEach(janre => { _context.FilmJanres.Remove(janre); _context.SaveChanges(); });

            // Add new related film country
            foreach (var country_id in user_data.FilmCounties)
            {
                var filmCountry = new FilmCountry
                {
                    FilmId = edit_film.ID,
                    CountryId = Convert.ToInt32(country_id)
                };

                _context.FilmCountries.Add(filmCountry);
            }

            // Add new related film janres
            foreach (var janre_id in user_data.FilmJanres)
            {
                var filmJanre = new FilmJanre
                {
                    FilmId = edit_film.ID,
                    JanreId = Convert.ToInt32(janre_id)
                };

                _context.FilmJanres.Add(filmJanre);
            }

            _context.SaveChanges();

            TempData["success"] = "Film ugurla editlendi.";

            if (Request["_continue"] != null)
            {
                return RedirectToAction("Edit","Home", new { id = user_data.Film.ID});
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Film film = null;
            film = _context.Films.FirstOrDefault(x => x.ID == id);
            // Cascade True will remove FilmCountry and FilmJanres
            _context.Films.Remove(film);
            _context.SaveChanges();
            TempData["success"] = "Film ugurla silindi.";

            return RedirectToAction("Index", "Home");            
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {

            var details = _context.Films.Where(x => x.ID == id).FirstOrDefault();

            if (details == null) return HttpNotFound();
            else return View(details);

        }

        protected override void Dispose(bool disposing)
        {
            // Release the db resources
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}