using Bookstore.Backend.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NSwag.CodeGeneration.TypeScript;
using NSwag;
using System.IO;
using System.Threading.Tasks;


namespace Bookstore.Backend.Tools
{
    public class SwaggerGenerator
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly SwaggerUrlConfiguration _swaggerUrlConfiguration;
        private readonly SwaggerPathConfiguration _swaggerPathConfiguration;
        public SwaggerGenerator(IWebHostEnvironment hostEnvironment,
            SwaggerUrlConfiguration swaggerUrlConfiruration,
            SwaggerPathConfiguration swaggerPathConfiruration)
        {
            _hostEnvironment = hostEnvironment;
            _swaggerUrlConfiguration = swaggerUrlConfiruration;
            _swaggerPathConfiguration = swaggerPathConfiruration;
        }

        public async Task<string> GenerateBackendTypescriptDefinition(TypeScriptClientGeneratorSettings settings = default, bool toFrontendFile = true)
        {
            var generator = new TypeScriptClientGenerator(
                await OpenApiDocument.FromUrlAsync(_swaggerUrlConfiguration.ApplicationUrlHTTP),
                settings ?? new TypeScriptClientGeneratorSettings
                {
                    Template = TypeScriptTemplate.Axios,
                }
            );
            var tsCode = generator.GenerateFile();
            if (toFrontendFile)
            {
                var fullPath = Path.GetFullPath(Path.Combine(_hostEnvironment.ContentRootPath, _swaggerPathConfiguration.MainGeneratedTypeScriptOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                await File.WriteAllTextAsync(fullPath, tsCode);
            }
            return tsCode;

        }
    }
}
