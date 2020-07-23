using System.ComponentModel.DataAnnotations;

namespace RestAPI.Resources
{
    public class SaveReviewResource
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 5)]
        public decimal Rating { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
