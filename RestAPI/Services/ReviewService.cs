using RestAPI.Domain.Models;
using RestAPI.Domain.Repositories;
using RestAPI.Domain.Services;
using RestAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> ListReviewsAsync(int movieId)
        {
            return await _reviewRepository.ListReviewsAsync(movieId);
        }

        public async Task<SaveReviewResponse> SaveReviewAsync(Review review)
        {
            try
            {
                await _reviewRepository.AddReviewAsync(review);
                await _unitOfWork.CompleteAsync();

                return new SaveReviewResponse(review);
            }
            catch (Exception ex)
            {
                return new SaveReviewResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
