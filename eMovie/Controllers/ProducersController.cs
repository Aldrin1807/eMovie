using eMovie.Data.DTOs;
using eMovie.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var producers = _service.GetAllProducers();
            return View(producers);
        }
        // GET: ProducersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producer = _service.GetProducerById(id);
            return View(producer);
        }   

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Bio,ProfilePictureURL")]ProducerDTO producer)
        {
            _service.AddProducer(producer);
            return RedirectToAction("Index");
        }

        // GET: ProducersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producer = _service.GetProducerById(id);
            return View(producer);
        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,Bio,ProfilePictureURL")]ProducerDTO producer)
        {
            _service.UpdateProducer(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //get: ProducersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producer = _service.GetProducerById(id);
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]    
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            _service.DeleteProducer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
