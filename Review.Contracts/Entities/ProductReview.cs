using System;

namespace Review.Contracts.Entities
{
    public class ProductReview
    {
        public Guid ProductReviewId { get; set; }
        public byte ProductReviewScore { get; set; }
        public string ProductReviewTitle { get; set; }
        public string ProductReviewComment { get; set; }
        public bool? ProductReviewIsRecommend { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}