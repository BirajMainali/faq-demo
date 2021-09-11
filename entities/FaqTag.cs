using FAQ.Infrastructure;
using FAQ.Infrastructure.Interface;

namespace FAQ.entities
{
    public class FaqTag : BaseModel, ISoftDelete
    {
        public Tag Tag { get; set; }
        public Faq Faq { get; set; }
    }
}