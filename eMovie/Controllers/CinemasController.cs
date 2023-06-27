using eMovie.Data.DTOs;
using eMovie.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eMovie.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var cinemas = _service.GetAllCinemas();
            return View(cinemas);
        }

        //GET: Cinemas/Create/5
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo","Name","Description")]CinemaDTO cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            _service.AddCinema(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.GetCinemaById(id);
            if (cinema == null)
            {
                return View("Empty");
            }
            return View(cinema);
        }

        //GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetCinemaById(id);
            if (cinema == null)
            {
                return View("Empty");
            }
            return View(cinema);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _service.DeleteCinema(id);
            return RedirectToAction(nameof(Index));
        }

        //GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetCinemaById(id);
            if (cinema == null)
            {
                return View("Empty");
            }
            return View(cinema);
        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Logo","Name","Description")]CinemaDTO cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            var updatedCinema =  _service.UpdateCinema(id, cinema);
            if (updatedCinema == null)
            {
                return View("Empty");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
