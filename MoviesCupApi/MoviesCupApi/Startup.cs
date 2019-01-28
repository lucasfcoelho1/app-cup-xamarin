using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesCupApi.Repositories;
using MoviesCupApi.Repositories.Interfaces;
using MoviesCupApi.Services;
using MoviesCupApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace MoviesCupApi
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
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<ICupService, CupService>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Movies Api", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x => 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API Version 1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
