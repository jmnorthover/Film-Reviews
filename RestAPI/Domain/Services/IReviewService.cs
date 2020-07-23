using RestAPI.Domain.Models;
using RestAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListReviewsAsync(int movieId);
        Task<SaveReviewResponse> SaveReviewAsync(Review review);
    }
}
