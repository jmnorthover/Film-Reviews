using RestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListReviewsAsync(int movieId);
        Task AddReviewAsync(Review newReview);
    }
}
