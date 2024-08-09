using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<NewMovieDropDownsViewModel> GetNewMovieDropDownsValues();
        Task AddNewMovieAsync(MovieViewModel data);

        Task UpdateMovieAsync(MovieViewModel data);

    }
}
