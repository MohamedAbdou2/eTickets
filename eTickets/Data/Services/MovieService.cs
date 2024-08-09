using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(MovieViewModel data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                Description = data.Description,
                CinemaId = data.CinemaId,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,

            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new ActorMovie()
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id,
                };
                await _context.ActorsMovies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewMovieDropDownsViewModel> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownsViewModel
            {
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateMovieAsync(MovieViewModel data)
        {
            var dbmovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbmovie != null)
            {
                dbmovie.Name = data.Name;
                dbmovie.StartDate = data.StartDate;
                dbmovie.EndDate = data.EndDate;
                dbmovie.Price = data.Price;
                dbmovie.ImageUrl = data.ImageUrl;
                dbmovie.Description = data.Description;
                dbmovie.CinemaId = data.CinemaId;
                dbmovie.MovieCategory = data.MovieCategory;
                dbmovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();

            }
            var existingActorsDb = _context.ActorsMovies.Where(n => n.MovieId == data.Id).ToList();
            _context.ActorsMovies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();


            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new ActorMovie()
                {
                    ActorId = actorId,
                    MovieId = data.Id,
                };
                await _context.ActorsMovies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
