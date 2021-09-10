using FAQ.Infrastructure;
using FAQ.Model;
using FAQ.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}