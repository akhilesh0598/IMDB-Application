using IMDB_API_Project.Connections;
using IMDB_API_Project.ImageUploaderFile;
using IMDB_API_Project.Repository;
using IMDB_API_Project.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IMDB_API_Project
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMDB_API_Project", Version = "v1" });
            });

            services.Configure<ConnectionString>(Configuration.GetSection(ConnectionString.SectionName));

            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IActorsRepository, ActorsRepository>();

            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IGenresRepository, GenresRepository>();

            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();

            services.AddScoped<IProducersService, ProducersService>();
            services.AddScoped<IProducersRepository, ProducersRepository>();

            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:8080", "https://localhost:44363")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDB_API_Project v1"));
            }
            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}