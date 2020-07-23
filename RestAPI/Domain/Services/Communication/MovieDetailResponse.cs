using RestAPI.Domain.Models;
using RestAPI.Resources;

namespace RestAPI.Domain.Services.Communication
{
    public class MovieDetailResponse : BaseResponse
    {
        public MovieDetailResource Details { get; private set; }

        private MovieDetailResponse(bool success, string message, MovieDetailResource details) : base(success, message)
        {
            Details = details;
        }

        public MovieDetailResponse(MovieDetailResource details) : this(true, string.Empty, details)
        { }

        public MovieDetailResponse(string message) : this(false, message, null)
        { }
    }
}
