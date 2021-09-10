using FAQ.Model;
using Microsoft.EntityFrameworkCore;

namespace FAQ
{
    public static class EntityRegisterer
    {
        public static ModelBuilder AddFaq(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("auth_user", schema: "user");
            builder.Entity<Faq>().ToTable("FAQ", schema: "FAQ");
            return builder;
        }
    }
}