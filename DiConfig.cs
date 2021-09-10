using FAQ.Data;
using FAQ.Infrastructure.Helper;
using FAQ.Infrastructure.Helper.Interface;
using FAQ.Infrastructure.Provider;
using FAQ.Infrastructure.Provider.Interface;
using FAQ.Repository;
using FAQ.Repository.Interface;
using FAQ.Services;
using FAQ.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FAQ
{
    public static class DiConfig
    {
        public static IServiceCollection UseConfiguration(this IServiceCollection services)
        {
            UseMisc(services);
            UseRepos(services);
            UseServices(services);
            return services;
        }

        private static void UseRepos(IServiceCollection services)
            => services.AddScoped<IFaqRepository, FaqRepository>()
                .AddScoped<IUserRepository, UserRepository>();

        private static void UseServices(IServiceCollection services)
            => services.AddScoped<IFaqService, FaqService>();

        private static void UseMisc(IServiceCollection services)
            => services.AddScoped<IImageHelper, ImageHelper>()
                .AddScoped<IUserProvider, UserProvider>()
                .AddScoped<DbContext, ApplicationDbContext>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}