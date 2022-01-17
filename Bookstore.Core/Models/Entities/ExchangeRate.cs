using Bookstore.Core.Enums;

namespace Bookstore.Core.Models.Entities
{
    public class ExchangeRate:  BaseModel
    {
        public Currency TypeCurrency { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Abbreviation { get; set; }
    }
}
