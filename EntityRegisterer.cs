using FAQ.entities;
using FAQ.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;

namespace FAQ
{
    public static class EntityRegisterer
    {
        public static ModelBuilder AddFaq(this ModelBuilder builder)
        {
            builder.Entity<Faq>().ToTable("faq_items", Schema.Faq);
            builder.Entity<Tag>().ToTable("tags", schema: Schema.Faq);
            builder.Entity<FaqTag>().ToTable("faq_tag", schema: Schema.Faq);
            builder.Entity<Tag>().HasData(
                new Tag { Id = 1, Slug = "Stakeholder" },
                new Tag { Id = 2, Slug = "Inventory", },
                new Tag { Id = 3, Slug = "Lekhastra Web" }
            );
            return builder;
        }
    }
}