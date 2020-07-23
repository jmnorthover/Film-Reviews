using RestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Repositories;

namespace RestAPI.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> ListReviewsAsync(int movieId)
        {
            return await _context.Reviews
                .Where(review => review.MovieId == movieId)
                .ToListAsync();
        }

        public async Task AddReviewAsync(Review newReview)
        {
            await _context.Reviews.AddAsync(newReview);
        }
    }
}
