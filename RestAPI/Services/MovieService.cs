using Newtonsoft.Json;
using RestAPI.Domain.Services;
using RestAPI.Domain.Services.Communication;
using RestAPI.Resources;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestAPI
{
    public class MovieService : IMovieService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MovieDetailResource MovieDetails { get; set; }

        public MovieService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<MovieDetailResponse> GetMovieDetailsAsync(int movieId)
        {
            var client = _clientFactory.CreateClient();
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");
            var url = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}&language=en-US";

            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<MovieDetailResource>(data);
                return new MovieDetailResponse(details);
            }

            else
            {
                return new MovieDetailResponse("Failed to fetch movie details.");
            }
        }

        public async Task<MovieSearchResponse> SearchMoviesAsync(string query)
        {
            var client = _clientFactory.CreateClient();
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language=en-US&query={query}&page=1";

            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<SearchResultResource>(data);
                return new MovieSearchResponse(results);
            }

            else
            {
                return new MovieSearchResponse("Failed to fetch movie details.");
            }
        }
    }
}