using AutoMapper;
using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using ecommerceweb.SharedModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceweb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _rating;
        public RatingController(IRatingRepository rating, IMapper mapper)
        {
            _rating = rating;
            _mapper = mapper;
        }

        // Get all ratings
        [HttpGet]
        public async Task<IActionResult> GetRatings()
        {
            try
            {
                var getRatings = await _rating.GetAsync();
                if (!getRatings.Any())
                {
                    return NotFound("There's no rating.");
                }
                var ratingDTO = _mapper.Map<List<RatingDTO>>(getRatings);
                return Ok(ratingDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Get 1 Rating
        [HttpGet("{RatingId}")]
        public async Task<IActionResult> GetRatingDetails(int RatingId)
        {
            try
            {
                var getRating = await _rating.GetByIdAsync(RatingId);
                if (getRating == null)
                {
                    return NotFound("There's no rating.");
                }
                var ratingDTO = _mapper.Map<RatingDTO>(getRating);
                return Ok(ratingDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Get ratings by ProductId
        [HttpGet("products/{ProductId}")]
        public async Task<IActionResult> GetRatingsByProductId(int ProductId)
        {
            try
            {
                var getRatings = await _rating.GetByProductIdAsync(ProductId);
                if (!getRatings.Any())
                {
                    return NotFound("There's no rating.");
                }
                var ratingDTO = _mapper.Map<List<RatingDTO>>(getRatings);
                return Ok(ratingDTO);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Creat 1 rating
        [HttpPost]
        public async Task<IActionResult> CreateRating(RatingDTO rating)
        {
            try
            {
                var createRating = _mapper.Map<Rating>(rating);
                var newrating = await _rating.PostAsync(createRating);
                var returnRating = _mapper.Map<RatingDTO>(newrating);
                return Ok(returnRating);
            }
            catch
            {
                return BadRequest("Ooops.");
            }

        }

        //Put Rating
        [HttpPut("{RatingId}")]
        public async Task<IActionResult> UpdateRating(int RatingId, RatingDTO rating)
        {
            try
            {
                var updateRating = _mapper.Map<Rating>(rating);
                var putRating = await _rating.PutAsync(RatingId, updateRating);
                var returnRating = _mapper.Map<RatingDTO>(putRating);
                return Ok(returnRating);
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        //Delete Rating
        [HttpDelete("{RatingId}")]
        public async Task<IActionResult> DeleteRating(int RatingId)
        {
            try
            {
                var deleteRating = await _rating.GetByIdAsync(RatingId);
                if (deleteRating == null)
                {
                    return NotFound("There's no rating.");
                }
                await _rating.DeleteAsync(RatingId);
                return Ok("Deleted successfully");
            }
            catch
            {
                return BadRequest("Ooops.");
            }
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
