﻿using System.Threading.Tasks;
using FAQ.entities;
using Microsoft.AspNetCore.Identity;

namespace FAQ.Infrastructure.Provider.Interface
{
    public interface IUserProvider
    {
        Task<IdentityUser> GetCurrentUser();
    }
}