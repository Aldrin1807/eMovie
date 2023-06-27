using eMovie.Data.DTOs;
using eMovie.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eMovie.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
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
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _service.DeleteCinema(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
