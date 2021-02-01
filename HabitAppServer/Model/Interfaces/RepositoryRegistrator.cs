using HabitAppServer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HabitAppServer.Model.Interfaces
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<User>, DBRepository<User>>()
            .AddTransient<IRepository<Habit>, DBRepository<Habit>>()
            .AddTransient<IRepository<Achievement>, DBRepository<Achievement>>()
            .AddTransient<IRepository<Chat>, DBRepository<Chat>>()
            .AddTransient<IRepository<UserGroup>, DBRepository<UserGroup>>()
            .AddTransient<IRepository<ChatMessage>, DBRepository<ChatMessage>>()
            .AddTransient<IRepository<Reward>, DBRepository<Reward>>()
            ;
    }
}
