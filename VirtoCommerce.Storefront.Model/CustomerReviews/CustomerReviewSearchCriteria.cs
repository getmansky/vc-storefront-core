using System.Collections.Specialized;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public partial class CustomerReviewSearchCriteria : PagedSearchCriteria
    {
        // TODO: Replace with autoproperty.
        private static int _defaultPageSize = 20;

        public static int DefaultPageSize
        {
            get => _defaultPageSize;
            set
            {
                _defaultPageSize = value;
            }
        }

        public CustomerReviewSearchCriteria()
            : base(new NameValueCollection(), _defaultPageSize) { }

        public CustomerReviewSearchCriteria(NameValueCollection queryString)
            : base(queryString, _defaultPageSize) { }

        public string[] ProductIds { get; set; }
        public bool? IsActive { get; set; }
        public string Sort { get; set; }
    }
}
