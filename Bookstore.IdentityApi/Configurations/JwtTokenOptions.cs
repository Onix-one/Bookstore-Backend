namespace Bookstore.IdentityApi.Configurations
{
    public class JwtTokenOptions
    {
        public const string SectionTitle = "JwtTokenOptions";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public int Lifetime { get; set; }

    }
}
