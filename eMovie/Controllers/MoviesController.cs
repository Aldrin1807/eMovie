using eMovie.Data;
using eMovie.Data.DTOs;
using eMovie.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies =await _service.GetAllMovies();
            return View(movies);
        }

        //Get: Movies/Create
        public async  Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieDTO movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await  _service.CreateMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        //GEt   : Movies/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetMovieById(id);
            if (movie == null)
            {
                return View("Empty");
            }
            return View(movie);
        }
        

        //GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetMovieById(id);
            if (movie == null)
            {
                return View("Empty");
            }


            var response = new MovieDTO()
            {
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ImageURL = movie.ImageURL,
                MovieCategory = movie.MovieCategory,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                ActorIds = movie.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);

        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Edit(int id,MovieDTO movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovie(movie);
            return RedirectToAction(nameof(Index));
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _service.Filter(searchString);
            return View("Index",movies);
        }

    }
}
