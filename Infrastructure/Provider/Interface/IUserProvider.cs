using System.Threading.Tasks;
using FAQ.Model;

namespace FAQ.Infrastructure.Provider.Interface
{
    public interface IUserProvider
    {
        Task<User> GetCurrentUser();
    }
}