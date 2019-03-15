using System;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    public class ReviewRating : Drop
    {
        public string AuthorNickname { get; set; }
        public string ReviewId { get; set; }
        public int? Rating { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
