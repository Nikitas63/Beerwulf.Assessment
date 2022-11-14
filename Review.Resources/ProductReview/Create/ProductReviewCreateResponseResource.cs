using System;
using Review.Resources.Base;

namespace Review.Resources.ProductReview.Create
{
    public class ProductReviewCreateResponseResource: BaseOperationResponseResource
    {
        public Guid ProductReviewId { get; set; }
        public int ProductReviewScore { get; set; }
        public string ProductReviewTitle { get; set; }
        public string ProductReviewComment { get; set; }
        public bool? ProductReviewIsRecommend { get; set; }
        
        public Guid ProductId { get; set; }
    }
}