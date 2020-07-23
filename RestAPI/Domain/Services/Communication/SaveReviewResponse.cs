using RestAPI.Domain.Models;

namespace RestAPI.Domain.Services.Communication
{
    public class SaveReviewResponse : BaseResponse
    {
        public Review Review { get; private set; }

        private SaveReviewResponse(bool success, string message, Review review) : base(success, message)
        {
            Review = review;
        }

        public SaveReviewResponse(Review review) : this(true, string.Empty, review)
        { }

        public SaveReviewResponse(string message) : this(false, message, null)
        { }
    }
}
