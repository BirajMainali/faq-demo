using System.Threading.Tasks;
using FAQ.entities;

namespace FAQ.Infrastructure.Provider.Interface
{
    public interface IUserProvider
    {
        Task<User> GetCurrentUser();
    }
}