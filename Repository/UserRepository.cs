using FAQ.entities;
using FAQ.Infrastructure;
using FAQ.Infrastructure.Base;
using FAQ.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository
{
    public class UserRepository : BaseRepository<IdentityUser>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}