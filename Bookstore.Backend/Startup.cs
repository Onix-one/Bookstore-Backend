using Bookstore.Backend.Configurations;
using Bookstore.Backend.Extensions;
using Bookstore.Backend.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

namespace Bookstore.Backend
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
            services.AddDatabaseContext(Configuration);
            services.AddConfigurations(Configuration);
            services.AddControllers();
                //.AddJsonOptions(x =>
                //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSwagger();
            services.AddAuthenticationWithJwtToken(Configuration);
            services.AddAuthorizationWithRole();
            services.AddMapper();
            services.AddServices(Configuration);
            services.AddRepositories(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IOptions<SwaggerUrlConfiguration> swaggerUrlConfiruration,
            IOptions<SwaggerPathConfiguration> swaggerPathConfiruration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookstore.Backend v1"));
                //GenerateClientsAsync(env, swaggerUrlConfiruration.Value, swaggerPathConfiruration.Value);
            }

            app.UseRouting();

            app.UseStaticFiles();

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
        }

        [Conditional("DEBUG")]
        private async void GenerateClientsAsync(IWebHostEnvironment env, SwaggerUrlConfiguration urlConfig, SwaggerPathConfiguration pathConfig)
        {
            var generator = new SwaggerGenerator(env, urlConfig, pathConfig);
            try
            {
                // Main (this) service generation
                await generator.GenerateBackendTypescriptDefinition();
            }
            catch { }
        }
    }
}
