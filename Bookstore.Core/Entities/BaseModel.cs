using Bookstore.Core.Interfaces;

namespace Bookstore.Core.Entities
{
    public abstract class BaseModel: IBaseModel
    {
        public int Id { get; set; }
    }
}
