using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.Primitives;
using VirtoCommerce.Storefront.Model.Common.Caching;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public class ReviewRatingCacheRegion : CancellableCacheRegion<ReviewRatingCacheRegion>
    {
        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _memberRegionTokenLookup =
          new ConcurrentDictionary<string, CancellationTokenSource>();

        public static IChangeToken CreateChangeToken(string customerId)
        {
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }
            var cancellationTokenSource = _memberRegionTokenLookup.GetOrAdd(customerId, new CancellationTokenSource());
            return new CompositeChangeToken(new[] { CreateChangeToken(), new CancellationChangeToken(cancellationTokenSource.Token) });
        }

        public static void ExpireMember(string customerId)
        {
            if (!string.IsNullOrEmpty(customerId) && _memberRegionTokenLookup.TryRemove(customerId, out var token))
            {
                token.Cancel();
            }
        }
    }
}
