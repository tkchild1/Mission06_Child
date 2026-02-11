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
            return View("MovieSubmission");
        }
        [HttpPost]
        public IActionResult MovieSubmission(Movie response)
        {
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges();
            return View("MovieConfirmation", response);
        }
    }
}
