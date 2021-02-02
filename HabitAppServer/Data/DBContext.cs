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
        public DbSet<CustomDateTime> CustomDateTimes { get; set; }



        public DBContext()
        {
            Database.Migrate();
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HabitAppDB;AttachDbFilename=C:\Users\user\source\repos\HabitApp\HabitAppServer\LocalDatabase\HabitAppDB.mdf;Trusted_Connection=True;");
        }
    }
}
