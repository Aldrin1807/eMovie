using eMovie.Data.DTOs;
using eMovie.Data.Services;
using eMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllActors();
            return View(data);
        }

        //GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]ActorDTO actor)
        {
           if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }


        //GET: Actors/Details/5
        public IActionResult Details(int id)
        {
            var actor = _service.GetActorById(id);
            if (actor == null)
            {
                return View("Empty");
            }
            return View(actor);
        }
    }
}
