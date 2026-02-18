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
        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllAbout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("MovieSubmission", new Movie());
        }
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
        public IActionResult Collection()
        {
            var app = _context.Movies
            .Include(m => m.Category)  // Add this back
            .OrderBy(x => x.Title)
            .ToList();
            return View(app);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
               .Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("MovieSubmission", recordToEdit);
        }
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();
            return RedirectToAction("Collection");
        }
    }
}
