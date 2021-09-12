using System.Threading.Tasks;
using FAQ.entities;
using FAQ.Infrastructure.Base;
using FAQ.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> FindUser(string id)
            => await GetQueryable().SingleOrDefaultAsync(x => x.Id == id);
    }
}