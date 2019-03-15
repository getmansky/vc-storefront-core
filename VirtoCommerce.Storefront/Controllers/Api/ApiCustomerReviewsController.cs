using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model;
using VirtoCommerce.Storefront.Model.Common;
using VirtoCommerce.Storefront.Model.CustomerReviews;
using VirtoCommerce.Storefront.Model.ReviewRatings;

namespace VirtoCommerce.Storefront.Controllers.Api
{
    [StorefrontApiRoute("customerReviews")]
    public class ApiCustomerReviewsController : StorefrontControllerBase
    {
        private readonly ICustomerReviewService _customerReviewService;

        public ApiCustomerReviewsController(IWorkContextAccessor workContextAccessor, IStorefrontUrlBuilder urlBuilder, ICustomerReviewService customerReviewService)
            : base(workContextAccessor, urlBuilder)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomerReview([FromBody] CustomerReview[] reviews)
        {
            await _customerReviewService.AddReviewAsync(reviews);

            return Ok();
        }

        [HttpPost("rate")]
        public async Task<ActionResult> RateReviw([FromBody] ReviewRating rating)
        {
            await _customerReviewService.RateReviewAsync(rating);

            return Ok();
        }
    }
}
