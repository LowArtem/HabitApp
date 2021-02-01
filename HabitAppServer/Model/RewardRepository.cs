using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    internal class RewardRepository : DBRepository<Reward>
    {
        public RewardRepository(DBContext context) : base(context) { }

        public override IQueryable<Reward> Items => base.Items.Include(item => item.Users)
                                                              .Include(item => item.Achievements);
    }
}
