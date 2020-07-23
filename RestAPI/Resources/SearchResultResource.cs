using System.Collections.Generic;

namespace RestAPI.Resources
{
    public class Result
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Release_Date { get; set; }
        public string Poster_Path { get; set; }
    }
    public class SearchResultResource
    {
        public IEnumerable<Result> Results { get; set; }
    }
}
