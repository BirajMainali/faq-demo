using FAQ.Infrastructure.Base.Interface.Base.BaseRepository.Interface;
using Microsoft.AspNetCore.Identity;

namespace FAQ.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<IdentityUser>
    {
    }
}