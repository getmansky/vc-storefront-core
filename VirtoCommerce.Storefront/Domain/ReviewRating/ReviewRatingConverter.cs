using ReviewDto = VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi.Models;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public static partial class ReviewRatingConverter
    {
        public static Model.ReviewRatings.ReviewRating ToReviewRating(this ReviewDto.CustomerReviewRating itemDto)
        {
            var result = new Model.ReviewRatings.ReviewRating
            {
                AuthorNickname = itemDto.AuthorNickname,
                CreatedBy = itemDto.AuthorNickname,
                CreatedDate = itemDto.CreatedDate,
                Id = itemDto.Id,
                ModifiedBy = itemDto.ModifiedBy,
                ModifiedDate = itemDto.ModifiedDate,
                Rating = itemDto.Rating,
                ReviewId = itemDto.ReviewId,
            };

            return result;
        }

        public static ReviewDto.CustomerReviewRating FromDto(this Model.ReviewRatings.ReviewRating rating)
        {
            var result = new ReviewDto.CustomerReviewRating
            {
                AuthorNickname = rating.AuthorNickname,
                CreatedBy = rating.CreatedBy,
                CreatedDate = rating.CreatedDate,
                Id = rating.Id,
                ModifiedBy = rating.ModifiedBy,
                ModifiedDate = rating.ModifiedDate,
                Rating = rating.Rating,
                ReviewId = rating.ReviewId
            };

            return result;
        }
    }
}
