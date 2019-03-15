using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PagedList.Core;
using VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model.Caching;
using VirtoCommerce.Storefront.Model.Common.Caching;
using VirtoCommerce.Storefront.Model.CustomerReviews;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ICustomerReviews _customerReviewsApi;
        private readonly IStorefrontMemoryCache _memoryCache;
        private readonly IApiChangesWatcher _changesWatcher;

        public CustomerReviewService(ICustomerReviews customerReviewsApi, IStorefrontMemoryCache memoryCash, IApiChangesWatcher changesWatcher)
        {
            _customerReviewsApi = customerReviewsApi;
            _memoryCache = memoryCash;
            _changesWatcher = changesWatcher;
        }

        public IPagedList<Model.CustomerReviews.CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria)
        {
            return SearchReviewAsync(criteria).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<Model.CustomerReviews.CustomerReview>> SearchReviewAsync(CustomerReviewSearchCriteria criteria)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(SearchReviewAsync), criteria.GetCacheKey());

            return await _memoryCache.GetOrCreateExclusiveAsync(cacheKey, async (cacheEntry) =>
            {
                cacheEntry.AddExpirationToken(CustomerReviewCacheRegion.CreateChangeToken());
                cacheEntry.AddExpirationToken(_changesWatcher.CreateChangeToken());

                var result = await _customerReviewsApi.SearchCustomerReviewsAsync(criteria.ToSearchCriteriaDto());
                return new StaticPagedList<Model.CustomerReviews.CustomerReview>(result.Results.Select(x => x.ToCustomerReview()),
                    criteria.PageNumber, criteria.PageSize, result.TotalCount.Value);
            });
        }

        public IPagedList<Model.ReviewRatings.ReviewRating> GetReviewRatings(string id)
        {
            return GetReviewRatingsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<Model.ReviewRatings.ReviewRating>> GetReviewRatingsAsync(string id)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(GetReviewRatingsAsync), id);
            return await _memoryCache.GetOrCreateExclusiveAsync(cacheKey, async (cacheEntry) =>
            {
                cacheEntry.AddExpirationToken(ReviewRatingCacheRegion.CreateChangeToken());
                cacheEntry.AddExpirationToken(_changesWatcher.CreateChangeToken());

                var result = await _customerReviewsApi.GetReviewRatingsAsync(id);
                return new StaticPagedList<Model.ReviewRatings.ReviewRating>(result.Results.Select(x => x.ToReviewRating()),
                    1, 20, result.TotalCount.Value);
            });
        }

        public void AddReview(IList<Model.CustomerReviews.CustomerReview> review)
        {
            AddReviewAsync(review).GetAwaiter().GetResult();
        }

        public async Task AddReviewAsync(IList<Model.CustomerReviews.CustomerReview> review)
        {
            await _customerReviewsApi.UpdateAsync(review.Select(x => x.FromDto()).ToList());
            CustomerReviewCacheRegion.ExpireRegion();
        }

        public void RateReview(Model.ReviewRatings.ReviewRating rating)
        {
            RateReviewAsync(rating).GetAwaiter().GetResult();
        }

        public async Task RateReviewAsync(Model.ReviewRatings.ReviewRating rating)
        {
            await _customerReviewsApi.RateAsync(rating.FromDto());
            ReviewRatingCacheRegion.ExpireRegion();
        }
    }
}
