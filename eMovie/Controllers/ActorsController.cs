using eMovie.Data;
using eMovie.Data.DTOs;
using eMovie.Data.Services;
using eMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Configuration;

namespace eMovie.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _service.GetActorById(id);
            if (actor == null)
            {
                return View("Empty");
            }
            return View(actor);
        }

        //GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetActorById(id);
            if (actor == null) {  return View("Empty");}
            return View(actor);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteActor(id);
            return RedirectToAction(nameof(Index));
        }


        //GET: Actors/Edit/5

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _service.GetActorById(id);
            if (actor == null) { return View("Empty"); }
            return View(actor);
        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,ProfilePictureURL,Bio")]ActorDTO actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           await _service.UpdateActor(id, actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
