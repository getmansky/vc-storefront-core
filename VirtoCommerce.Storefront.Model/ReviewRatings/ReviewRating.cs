using System;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.ReviewRatings
{
    public class ReviewRating : Entity
    {
        public string AuthorNickname { get; set; }
        public int? Rating { get; set; }
        public string ReviewId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
