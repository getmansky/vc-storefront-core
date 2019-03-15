using VirtoCommerce.LiquidThemeEngine.Objects;
using storefrontModel = VirtoCommerce.Storefront.Model.ReviewRatings;

namespace VirtoCommerce.LiquidThemeEngine.Converters
{
    public static class ReviewRatingConverter
    {
        public static ReviewRating ToShopifyModel(this storefrontModel.ReviewRating item)
        {
            return new ShopifyModelConverter().ToLiquidReviewRating(item);
        }
    }

    public partial class ShopifyModelConverter
    {
        public virtual ReviewRating ToLiquidReviewRating(storefrontModel.ReviewRating item)
        {
            return new ReviewRating
            {
                AuthorNickname = item.AuthorNickname,
                CreatedDate = item.CreatedDate,
                ReviewId = item.ReviewId,
                Rating = item.Rating
            };
        }
    }
}
