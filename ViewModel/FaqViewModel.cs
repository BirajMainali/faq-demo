using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FAQ.entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FAQ.ViewModel
{
    public class FaqViewModel
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        [DisplayName("Tags")]
        public long[] TagIds { get; set; }

        public List<Faq> Faqs;
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public SelectList TagOptions()
            => new(Tags, nameof(Tag.Id), nameof(Tag.Slug), TagIds);
    }
}