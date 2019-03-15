using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList.Core;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public interface ICustomerReviewService
    {
        IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria);
        Task<IPagedList<CustomerReview>> SearchReviewAsync(CustomerReviewSearchCriteria criteria);
        IPagedList<Model.ReviewRatings.ReviewRating> GetReviewRatings(string id);
        Task<IPagedList<Model.ReviewRatings.ReviewRating>> GetReviewRatingsAsync(string id);
        void AddReview(IList<Model.CustomerReviews.CustomerReview> review);
        Task AddReviewAsync(IList<Model.CustomerReviews.CustomerReview> review);
        void RateReview(Model.ReviewRatings.ReviewRating rating);
        Task RateReviewAsync(Model.ReviewRatings.ReviewRating rating);
    }
}
