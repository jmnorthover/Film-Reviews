namespace RestAPI.Resources
{
    public class MovieDetailResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Release_Date { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
    }
}
