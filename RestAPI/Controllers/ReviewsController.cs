using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Domain.Models;
using RestAPI.Domain.Services;
using RestAPI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestAPI.Extensions;

namespace RestAPI.Controllers
{
    [Route("/api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetReviewsAsync([FromRoute] int movieId)
        {
            var reviews = await _reviewService.ListReviewsAsync(movieId);
            var reviewResources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);

            return Ok(reviewResources);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var newReview = _mapper.Map<SaveReviewResource, Review>(resource);

            var result = await _reviewService.SaveReviewAsync(newReview);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Review);
            return Ok(reviewResource);
        }
    }
}
