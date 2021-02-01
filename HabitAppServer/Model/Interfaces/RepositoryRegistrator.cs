using HabitAppServer.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HabitAppServer.Model.Interfaces
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<User>, UserRepository>()
            .AddTransient<IRepository<Habit>, HabitRepository>()
            .AddTransient<IRepository<Achievement>, AchievementRepository>()
            .AddTransient<IRepository<Chat>, ChatRepository>()
            .AddTransient<IRepository<UserGroup>, UserGroupRepository>()
            .AddTransient<IRepository<ChatMessage>, ChatMessageRepository>()
            .AddTransient<IRepository<Reward>, RewardRepository>()
            ;
    }
}
