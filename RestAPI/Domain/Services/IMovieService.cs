using RestAPI.Domain.Models;
using RestAPI.Domain.Services.Communication;
using RestAPI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Domain.Services
{
    public interface IMovieService
    {
        Task<MovieDetailResponse> GetMovieDetailsAsync(int movieId);

        Task<MovieSearchResponse> SearchMoviesAsync(string query);
    }
}