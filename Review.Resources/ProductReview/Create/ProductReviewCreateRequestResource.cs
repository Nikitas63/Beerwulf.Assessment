namespace Review.Resources.ProductReview.Create
{
    public class ProductReviewCreateRequestResource
    {
        public int ProductReviewScore { get; set; }
        public string ProductReviewTitle { get; set; }
        public string ProductReviewComment { get; set; }
        public bool? ProductReviewIsRecommend { get; set; }
    }
}