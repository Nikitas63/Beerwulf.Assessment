using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Review.Business.Services;
using Review.Contracts.BusinessModels;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Repositories;

namespace Review.UnitTest
{
    [TestFixture]
    public class ProductReviewServiceTests
    {
        private readonly IFixture _fixture = new Fixture();
        
        private readonly Mock<IProductReviewRepository> _productReviewRepositoryMock = new();
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly ProductReviewService _sut;

        public ProductReviewServiceTests()
        {
            _sut = new ProductReviewService(
                _productReviewRepositoryMock.Object,
                _productRepositoryMock.Object);
        }

        [Test]
        public async Task GetProductReviewsSummary_ShouldBeOk()
        {
            // Arrange
            // TODO: use test case source
            var productId = _fixture.Create<Guid>();
            var reviews = new[]
            {
                _fixture.Build<ProductReview>()
                    .Without(r => r.Product)
                    .With(r => r.ProductReviewScore, 2)
                    .With(r => r.ProductReviewIsRecommend, true)
                    .Create(),

                _fixture.Build<ProductReview>()
                    .Without(r => r.Product)
                    .With(r => r.ProductReviewScore, 5)
                    .With(r => r.ProductReviewIsRecommend, true)
                    .Create(),

                _fixture.Build<ProductReview>()
                    .Without(r => r.Product)
                    .With(r => r.ProductReviewScore, 4)
                    .With(r => r.ProductReviewIsRecommend, false)
                    .Create(),

                _fixture.Build<ProductReview>()
                    .Without(r => r.Product)
                    .With(r => r.ProductReviewScore, 1)
                    .With(r => r.ProductReviewIsRecommend, false)
                    .Create()
            };
            var reviewsPage = _fixture.Build<Page<ProductReview>>()
                .With(s => s.Data, reviews)
                .Create();

            var expected = _fixture.Build<ProductReviewsSummary>()
                .With(s => s.AverageScore, 3)
                .With(s => s.PercentOfRecommendations, 50)
                .Create();

            _productReviewRepositoryMock
                .Setup(m => m.GetProductReviewsAsync(productId, It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(reviewsPage);

            // Act
            var summary = await _sut.GetProductReviewsSummaryAsync(productId);

            // Assert
            summary.Should().BeEquivalentTo(expected);
        }
    }
}