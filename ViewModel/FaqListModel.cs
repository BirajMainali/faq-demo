using System.Collections.Generic;
using FAQ.entities;

namespace FAQ.ViewModel
{
    public class FaqListModel
    {
        public string Search { get; set; }
        public List<Faq> Faqs { get; set; } = new List<Faq>();
        public List<FaqTag> Tags { get; set; }
    }
}