using System;
using System.Runtime.Serialization;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    public class CustomerReview : Drop
    {
        public string AuthorNickname { get; set; }
        public string Content { get; set; }
        public bool? IsActive { get; set; }
        public string ProductId { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Id { get; set; }


        public int AverageRating
        {
            get
            {
                var result = 0;
                foreach (var rating in ReviewRatings)
                {
                    if (rating.Rating != null)
                        result += rating.Rating.Value;
                }


                result = (int)Math.Round(decimal.ToDouble(result) / ReviewRatings.Length, 0, MidpointRounding.AwayFromZero);

                return result;

            }
        }


        [DataMember]
        public ReviewRating[] ReviewRatings { get; set; }
    }
}
