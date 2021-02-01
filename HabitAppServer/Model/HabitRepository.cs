using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    internal class HabitRepository : DBRepository<Habit>
    {
        public HabitRepository(DBContext context) : base(context) { }

        public override IQueryable<Habit> Items => base.Items.Include(item => item.User)
                                                             .Include(item => item.CompletionsDates);
    }
}
