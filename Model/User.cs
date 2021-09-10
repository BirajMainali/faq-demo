using FAQ.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;

namespace FAQ.Model
{
    public class User : IdentityUser, ISoftDelete
    {
    }
}