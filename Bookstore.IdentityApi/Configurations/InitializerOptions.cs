namespace Bookstore.IdentityApi.Configurations
{
    public class InitializerOptions
    {
        public const string SectionTitle = "InitializerOptions";
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerPassword { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
    }
}
