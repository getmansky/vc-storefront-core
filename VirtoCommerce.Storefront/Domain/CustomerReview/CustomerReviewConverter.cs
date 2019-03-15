using VirtoCommerce.Storefront.Model.CustomerReviews;
using ReviewDto = VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi.Models;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public static partial class CustomerReviewConverter
    {
        public static Model.CustomerReviews.CustomerReview ToCustomerReview(this ReviewDto.CustomerReview itemDto)
        {
            var result = new Model.CustomerReviews.CustomerReview
            {
                Id = itemDto.Id,
                AuthorNickname = itemDto.AuthorNickname,
                Content = itemDto.Content,
                CreatedBy = itemDto.CreatedBy,
                CreatedDate = itemDto.CreatedDate,
                IsActive = itemDto.IsActive,
                ModifiedDate = itemDto.ModifiedDate,
                ModifiedBy = itemDto.ModifiedBy,
                ProductId = itemDto.ProductId,
                Rating = itemDto.Rating
            };

            return result;
        }

        public static ReviewDto.CustomerReview FromDto(this Model.CustomerReviews.CustomerReview review)
        {
            var result = new ReviewDto.CustomerReview
            {
                AuthorNickname = review.AuthorNickname,
                Content = review.Content,
                CreatedBy = review.CreatedBy,
                CreatedDate = review.CreatedDate,
                Id = review.Id,
                IsActive = review.IsActive,
                ModifiedBy = review.ModifiedBy,
                ModifiedDate = review.ModifiedDate,
                ProductId = review.ProductId,
                Rating = review.Rating
            };

            return result;
        }

        public static ReviewDto.CustomerReviewSearchCriteria ToSearchCriteriaDto(this CustomerReviewSearchCriteria criteria)
        {
            var result = new ReviewDto.CustomerReviewSearchCriteria
            {
                IsActive = criteria.IsActive,
                ProductIds = criteria.ProductIds,

                Skip = criteria.Start,
                Sort = criteria.Sort,
                Take = criteria.PageSize
            };

            return result;
        }
    }
}
