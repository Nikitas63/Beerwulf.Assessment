using System;

namespace Review.Resources.ProductReview
{
    public class ProductReviewResource
    {
        public Guid ProductReviewId { get; set; }
        public int ProductReviewScore { get; set; }
        public string ProductReviewTitle { get; set; }
        public string ProductReviewComment { get; set; }
        public bool? ProductReviewIsRecommend { get; set; }
    }
}