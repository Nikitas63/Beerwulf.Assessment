using AutoMapper;
using Review.Contracts.BusinessModels;
using Review.Contracts.Entities;
using Review.Contracts.Pagination;
using Review.Contracts.Result;
using Review.Resources.Base;
using Review.Resources.Pagination;
using Review.Resources.Product;
using Review.Resources.ProductReview;
using Review.Resources.ProductReview.Create;

namespace Review.API.AppStart
{
    public static class AutoMapperConfig
    {
        public static IConfigurationProvider Configure()
        { 
            var config=  new MapperConfiguration(cfg =>
            { 
                cfg.CreateMap<PaginationContext, PaginationContextResource>(); 
                cfg.CreateMap(typeof(Page<>), typeof(PageResource<>));
                
                cfg.CreateMap<Product, ProductResource>();

                cfg.CreateMap<ProductReview, ProductReviewResource>();
                cfg.CreateMap<ProductReviewsSummary, ProductReviewsSummaryResource>();

                cfg.CreateMap<ProductReviewCreateRequestResource, ProductReview>()
                    .ForMember(r => r.ProductReviewId, opt => opt.Ignore())
                    .ForMember(r => r.Product, opt => opt.Ignore());

                cfg.CreateMap<ErrorModel, ErrorResource>();
                cfg.CreateMap<OperationResult<ProductReview>, ProductReviewCreateResponseResource>()
                    .ForMember(r => r.ProductReviewId,
                            opt => opt.MapFrom(v => v.Payload.ProductReviewId))
                    .ForMember(r => r.ProductReviewScore,
                        opt => opt.MapFrom(v => v.Payload.ProductReviewScore))
                    .ForMember(r => r.ProductReviewTitle,
                        opt => opt.MapFrom(v => v.Payload.ProductReviewTitle))
                    .ForMember(r => r.ProductReviewComment,
                        opt => opt.MapFrom(v => v.Payload.ProductReviewComment))
                    .ForMember(r => r.ProductReviewIsRecommend,
                        opt => opt.MapFrom(v => v.Payload.ProductReviewIsRecommend))
                    .ForMember(r => r.ProductId,
                        opt => opt.MapFrom(v => v.Payload.ProductId))
                    .ForMember(r => r.Errors,
                        opt => opt.MapFrom(v => v.Errors));
                });
                config.AssertConfigurationIsValid();
                return config;
            }
    }
}