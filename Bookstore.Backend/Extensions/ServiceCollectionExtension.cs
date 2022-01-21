using AutoMapper;
using Bookstore.Backend.Tools;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Services;
using Bookstore.DAL.ADO.Repositories;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
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

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore.Backend", Version = "v1" });
            });
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

        }
    }
}