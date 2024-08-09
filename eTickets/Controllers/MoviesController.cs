using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;

        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _movieService.GetAllAsync();
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _movieService.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetByIdAsync(id);
            if (movieDetails == null) { return View("NotFound"); }
            return View(movieDetails);

        }

        public async Task<IActionResult> Create()
        {
            var viewModelDropDowns = await _movieService.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(viewModelDropDowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(viewModelDropDowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(viewModelDropDowns.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModelDropDowns = await _movieService.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(viewModelDropDowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(viewModelDropDowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(viewModelDropDowns.Actors, "Id", "FullName");
                return View(model);
            }

            await _movieService.AddNewMovieAsync(model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            var MovieDetails = await _movieService.GetByIdAsync(id);
            if (MovieDetails == null) { return View("NotFound"); }
            var response = new MovieViewModel()
            {
                Id = MovieDetails.Id,
                Name = MovieDetails.Name,
                Description = MovieDetails.Description,
                Price = MovieDetails.Price,
                ImageUrl = MovieDetails.ImageUrl,
                StartDate = MovieDetails.StartDate,
                EndDate = MovieDetails.EndDate,
                MovieCategory = MovieDetails.MovieCategory,
                CinemaId = MovieDetails.CinemaId,
                ProducerId = MovieDetails.ProducerId,
                ActorIds = MovieDetails.ActorMovie.Select(n => n.ActorId).ToList(),


            };
            var viewModelDropDowns = await _movieService.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(viewModelDropDowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(viewModelDropDowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(viewModelDropDowns.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieViewModel model)
        {
            if (id != model.Id) { return View("NotFound"); }
            if (!ModelState.IsValid)
            {
                var viewModelDropDowns = await _movieService.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(viewModelDropDowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(viewModelDropDowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(viewModelDropDowns.Actors, "Id", "FullName");
                return View(model);
            }

            await _movieService.UpdateMovieAsync(model);
            return RedirectToAction("Index");

        }


    }
}
