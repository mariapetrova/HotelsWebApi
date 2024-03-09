using Hotels.Api.Core.Repositories;
using Hotels.Api.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

namespace Hotels.Api
{
    public class Startup
    {
        public Startup(
           IConfiguration configuration,
           IWebHostEnvironment environment)
        {
            Configuration = configuration;
            HostingEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<IHotelRepository>(provider =>
            {
                var jsonFilePath = Configuration.GetSection("FileSettings:JsonFilePath").Value; 
                return new HotelRepository(provider.GetRequiredService<IMemoryCache>(), jsonFilePath);
            });

            services.AddScoped<IHotelDataService, HotelDataService>();

            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Payload View API",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payload Management API V1");
            });
        }
    }
}