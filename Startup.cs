using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchEngines.Data;
using SearchEngines.Data.ApiModels.GoogleCustomSearch;
using SearchEngines.Data.Clients;
using SearchEngines.Data.Repository;
using SearchEngines.Mappings;
using SearchEngines.Services;
using AutoMapper;
using SearchEngines.Data.ApiModels.YandexXmlSearch;
using SearchEngines.Data.ApiModels.BingCustomSearch;

namespace SearchEngines
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
            services.AddAutoMapper(typeof(DomainProfile));
            services.AddControllersWithViews();

            services.AddDbContext<SearchEnginesDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISearchResultRepository, SearchResultRepository>();
            services.AddScoped<ISearchEngineRepository, SearchEngineRepository>();
            services.AddScoped<ISearchClient<GoogleSearchResultModel>, GoogleCustomSearchClient>();
            services.AddScoped<ISearchClient<YandexSearchResultModel>, YandexXmlSearchClient>();
            services.AddScoped<ISearchClient<BingCustomSearchResponseModel>, BingCustomSearchClient>();
            services.AddScoped<SearchService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Search}/{action=Search}/{id?}");
            });
        }
    }
}
