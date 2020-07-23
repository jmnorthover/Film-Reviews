namespace RestAPI.Resources

{
    public class ReviewResource
    {
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}