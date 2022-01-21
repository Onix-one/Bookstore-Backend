using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Backend.Configurations
{
    public class JwtOptions
    {
        public const string SectionTitle = "JwtOptions";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public SecurityKey Key { get; set; }

        public int Lifetime { get; set; }

        public JwtOptions(IConfiguration configuration)
        {
            Issuer = configuration["JwtOptions:Issuer"];
            Audience = configuration["JwtOptions:Audience"];
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtOptions:Key"]));
            Lifetime = int.Parse(configuration["JwtOptions:Lifetime"]);
        }

    }
}
