using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FAQ.entities;
using FAQ.Infrastructure.Provider.Interface;
using FAQ.Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace FAQ.Infrastructure.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;

        public UserProvider(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public bool IsLoggedIn()
        {
            return GetCurrentUserId() != null;
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = GetCurrentUserId();
            if (userId.HasValue) return await _userRepository.FindOrThrowAsync(userId.Value);
            return null;
        }

        public long? GetCurrentUserId()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue("Id");
            if (string.IsNullOrWhiteSpace(userId)) return null;
            return Convert.ToInt64(userId);
        }
    }
}