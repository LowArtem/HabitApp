using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    internal class AchievementRepository : DBRepository<Achievement>
    {
        public AchievementRepository(DBContext context) : base(context) { }

        public override IQueryable<Achievement> Items => base.Items.Include(item => item.Users)
                                                                   .Include(item => item.Rewards)
                                                                   .Include(item => item.UserGroups);
    }
}
