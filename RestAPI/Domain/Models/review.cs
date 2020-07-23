namespace RestAPI.Domain.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int MovieId { get; set; }

        public string Author { get; set; }

        public decimal Rating { get; set; }

        public string Description { get; set; }
    }
}
