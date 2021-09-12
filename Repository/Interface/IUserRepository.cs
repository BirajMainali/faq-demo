using System.Threading.Tasks;
using FAQ.entities;
using FAQ.Infrastructure.Base.Interface.Base.BaseRepository.Interface;

namespace FAQ.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindUser(string id);
    }
}