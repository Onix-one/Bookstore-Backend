using System;
using Bookstore.IdentityApi.Configurations;
using Bookstore.IdentityApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bookstore.IdentityApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDatabaseContext(Configuration);
            services.AddConfigurations(Configuration);
            services.AddMapper();
            services.AddIdentityConfiguration();
            services.AddAuthenticationWithJwtToken(Configuration);
            services.AddAuthorizationWithRole();
            services.AddServices();

            services.AddControllers();
            
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider,
            IOptions<InitializerOptions> securityOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookstore.IdentityApi v1"));
            }

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            IdentityInitializer.InitializeAsync(serviceProvider, securityOptions).Wait();
        }
    }
}
