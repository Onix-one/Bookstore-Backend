using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Bookstore.Backend.Configurations;
using Bookstore.Backend.Tools;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Services;
using Bookstore.DAL.ADO.Repositories;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Context;
using Bookstore.DAL.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Bookstore.Backend.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<AutoMapper.IConfigurationProvider>(x =>
                new MapperConfiguration(cfg
                    => cfg.AddProfile(new SourceMappingProfile())));
            services.AddSingleton<IMapper, Mapper>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookImageService, BookImageService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IGenreOfBookService, GenreOfBookService>();
            services.AddTransient<IFileService, FileService>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepositoryAdo, BookRepositoryAdo>();
            services.AddTransient<IBookImageRepository, BookImageRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IGenreOfBookRepository, GenreOfBookRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepositoryAdo, AuthorRepositoryAdo>();

        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore.IdentityApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
        public static void AddAuthenticationWithJwtToken(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(options => new JwtOptions(configuration));
            var jwtOptions = new JwtOptions(configuration);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = jwtOptions.Key,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true
                    };
                });
        }

        public static void AddAuthorizationWithRole(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorRights", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "admin");
                });
                options.AddPolicy("ManagerRights", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "admin", "manager");
                });
                options.AddPolicy("CustomerRights", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "customer");
                });
            });
        }

        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerUrlConfiguration>(configuration.GetSection("SwaggerUrlConfiguration"));
            services.Configure<SwaggerPathConfiguration>(configuration.GetSection("SwaggerPathConfiguration"));
        }

        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("bookStore");

            services.AddDbContext<BookStoreDbContext>(x =>
                x.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging());
        }
    }
}