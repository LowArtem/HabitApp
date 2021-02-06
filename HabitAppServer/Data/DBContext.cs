using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public DbSet<CustomDateTime> CustomDateTimes { get; set; }


        public DBContext()
        {
            // Непонятным образом это работает в случае, если база данных отказывается создавать таблицы
            //if (Database.CanConnect())
            //    Database.CloseConnection();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            Database.Migrate();
        }

        public DBContext(DbContextOptions<DBContext> options, ILogger<DBContext> logger) : base(options)
        {
            //if (Database.CanConnect())
            //    Database.CloseConnection();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();



            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HabitAppDB;Trusted_Connection=True;");
        }
    }
}
