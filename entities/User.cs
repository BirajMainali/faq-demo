using FAQ.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;

namespace FAQ.entities
{
    public class User : IdentityUser, ISoftDelete
    {
    }
}