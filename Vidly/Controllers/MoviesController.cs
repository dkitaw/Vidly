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