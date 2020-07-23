using System.Collections.Generic;
using RestAPI.Resources;

namespace RestAPI.Domain.Services.Communication
{
    public class MovieSearchResponse : BaseResponse
    {
        public SearchResultResource Results { get; private set; }

        private MovieSearchResponse(bool success, string message, SearchResultResource results) : base(success, message)
        {
            Results = results;
        }

        public MovieSearchResponse(SearchResultResource results) : this(true, string.Empty, results)
        { }

        public MovieSearchResponse(string message) : this(false, message, null)
        { }
    }
}