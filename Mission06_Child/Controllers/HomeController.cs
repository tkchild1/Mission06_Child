using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Child.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Child.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;
        // Constructor - injects database context
        public HomeController(MovieContext temp) 
        {
            _context = temp;
        }
        // Display home page
        public IActionResult Index()
        {
            return View();
        }
        // Display "Get to Know Joel" page
        public IActionResult AllAbout()
        {
            return View();
        }
        // GET: Display form to add a new movie
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("MovieSubmission", new Movie());
        }
        // POST: Save new movie to database
        [HttpPost]
        public IActionResult MovieSubmission(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("MovieConfirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View("MovieSubmission", response);
            }
        }
        // Display all movies in collection
        public IActionResult Collection()
        {
            var app = _context.Movies
            .Include(m => m.Category)  // Add this back
            .OrderBy(x => x.Title)
            .ToList();
            return View(app);
        }
        // GET: Load movie data for editing
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
               .Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("MovieSubmission", recordToEdit);
        }
        // POST: Save edited movie to database
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("Collection");
            }
            else
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
                return View("MovieSubmission", updatedInfo);
            }
        }
        // GET: Display confirmation page before deleting
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }
        // POST: Remove movie from database
        [HttpPost]
        public IActionResult Delete(Movie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();
            return RedirectToAction("Collection");
        }
    }
}
