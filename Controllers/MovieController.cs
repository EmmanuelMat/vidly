using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public readonly ApplicationDbContext db;

        public MovieController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var movies = db.Movie.Include(m => m.Genre).ToList();
            return View(movies);
        } 

        public IActionResult Detail(int id)
        {
            var movies = db.Movie.SingleOrDefault(m => m.Id == id);
            return View(movies);
        }
        
        public IActionResult MovieForm()
        {
            var genre = db.Genre.ToList();
            var viewModel = new GenreMovieViewModel
            {
                
                Genre = genre
            };
            
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new GenreMovieViewModel(movie)
                {
                    
                    Genre = db.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
            db.Add(movie);
            else{
                var movieInDb = db.Movie.Single(m => m.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.NumberOnStuck = movie.NumberOnStuck;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.Genre = movie.Genre;
            }
            db.SaveChanges();
            return  RedirectToAction("Index", "Movie");
        }
      
        public IActionResult Edit(int id)
        {
            var movies = db.Movie.SingleOrDefault(m => m.Id == id);
            if(movies == null)
             return Content("Not found");              

            var viewModel = new GenreMovieViewModel(movies)
            {
               
                Genre = db.Genre.ToList()
            };

             return View("MovieForm", viewModel);  
        }
    }
}
 