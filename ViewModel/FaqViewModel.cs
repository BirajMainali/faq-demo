using System.Collections.Generic;
using FAQ.entities;

namespace FAQ.ViewModel
{
    public class FaqViewModel
    {
        public string Question { get; set; }
        public List<long> Tags { get; set; }
        public string Answer { get; set; }
    }
}