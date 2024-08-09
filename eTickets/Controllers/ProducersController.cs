using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _producerService.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) { return View("NotFound"); }
            return View(producerDetails);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (!ModelState.IsValid) { return View(producer); }
            await _producerService.AddAsync(producer);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetails = await _producerService.GetByIdAsync(id);
            if (ProducerDetails == null) { return View("NotFound"); }

            return View(ProducerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid) { return View(producer); }
            if (id == producer.Id)
            {
                await _producerService.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetails = await _producerService.GetByIdAsync(id);
            if (ProducerDetails == null) { return View("NotFound"); }

            return View(ProducerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetails = await _producerService.GetByIdAsync(id);
            if (ProducerDetails == null) { return View("NotFound"); }
            await _producerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
