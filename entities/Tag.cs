using FAQ.Infrastructure;
using FAQ.Infrastructure.Base;
using FAQ.Infrastructure.Base.Interface;

namespace FAQ.entities
{
    public class Tag : BaseModel, ISoftDelete
    {
        public string Slug { get; set; }
    }
}