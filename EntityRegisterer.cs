using FAQ.entities;
using Microsoft.EntityFrameworkCore;

namespace FAQ
{
    public static class EntityRegisterer
    {
        public static ModelBuilder AddFaq(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("auth_user", schema: "user");
            builder.Entity<Faq>().ToTable("FAQ", schema: "FAQ");
            builder.Entity<Tag>().ToTable("tag", schema: "FAQ");
            builder.Entity<FaqTag>().ToTable("faq_tag", schema: "FAQ");
            builder.Entity<Tag>().HasData(
                new Tag { Id = 1, Slug = "Stakeholder" },
                new Tag { Id = 2, Slug = "Inventory", },
                new Tag { Id = 3, Slug = "Web" }
            );
            return builder;
        }
    }
}