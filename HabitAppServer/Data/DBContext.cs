using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Data
{
    public class DBContext : DbContext
    {
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
