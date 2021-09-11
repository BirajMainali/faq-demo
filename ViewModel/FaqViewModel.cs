using System.Collections.Generic;
using FAQ.entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FAQ.ViewModel
{
    public class FaqViewModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public long[] TagIds { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public SelectList TagOptions()
            => new(Tags, nameof(Tag.Id), nameof(Tag.Slug), TagIds);
    }
}