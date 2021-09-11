using FAQ.Infrastructure;
using FAQ.Infrastructure.Interface;

namespace FAQ.entities
{
    public class Tag : BaseModel, ISoftDelete
    {
        public string Slug { get; set; }
    }
}