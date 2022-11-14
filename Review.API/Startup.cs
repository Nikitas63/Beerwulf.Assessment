﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Review.API.AppStart;
using Review.Business.Services;
using Review.Contracts.Entities;
using Review.Contracts.Repositories;
using Review.Contracts.Services;
using Review.DataAccess;
using Review.DataAccess.Repositories;

namespace Review.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductReviewDbContext>();
            
            services.AddTransient<IProductReviewService, ProductReviewService>();
            services.AddTransient<IProductReviewRepository, ProductReviewRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton(AutoMapperConfig.Configure().CreateMapper());

            services
                .AddMvc(a => { a.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Review API", Version = "v1"});
            });

            using (var context = new ProductReviewDbContext())
            {
                context.Database.EnsureCreated();
            
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Test1",
                    ProductDescription = "Desc"
                });
            
                context.Products.Add(new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Test2",
                    ProductDescription = "Desc"
                });
            
                context.SaveChanges();
            }
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Review API(v1)");
            });
        }
    }
}