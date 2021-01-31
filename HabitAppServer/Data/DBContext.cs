using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Data
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }


        public DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HabitAppDB;Trusted_Connection=True;");
        }
    }
}
