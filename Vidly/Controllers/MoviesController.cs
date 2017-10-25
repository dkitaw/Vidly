using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();     
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Mcvies
        [Route("/Movies/Index")]
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(g=>g.Genre).ToList();
            return View(movies);
        }
        public ActionResult New()
        {
            
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel();


            viewModel.Genre = genre;
            
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

            }
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {

                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;
            }
            
            _context.SaveChanges();
            
           
            
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Edit(int id)
        {
            
            var movie = _context.Movies.Single(m=>m.Id==id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genre=_context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }
        [Route("/Movies/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id==Id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}