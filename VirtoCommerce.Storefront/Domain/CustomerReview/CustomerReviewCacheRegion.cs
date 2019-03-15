using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.Primitives;
using VirtoCommerce.Storefront.Model.Common.Caching;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public class CustomerReviewCacheRegion : CancellableCacheRegion<CustomerReviewCacheRegion>
    {
        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _memberRegionTokenLookup =
          new ConcurrentDictionary<string, CancellationTokenSource>();

        public static IChangeToken CreateChangeToken(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var cancellationTokenSource = _memberRegionTokenLookup.GetOrAdd(id, new CancellationTokenSource());
            return new CompositeChangeToken(new[] { CreateChangeToken(), new CancellationChangeToken(cancellationTokenSource.Token) });
        }

        public static void ExpireMember(string id)
        {
            if (!string.IsNullOrEmpty(id) && _memberRegionTokenLookup.TryRemove(id, out var token))
            {
                token.Cancel();
            }
        }
    }
}
