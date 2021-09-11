using System.Collections.Generic;
using FAQ.entities;

namespace FAQ.Dto
{
    public class FaqTagDto
    {
        public List<Tag> Tags { get; set; }
        public Faq Faq { get; set; }
    }
}