using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    internal class UserGroupRepository : DBRepository<UserGroup>
    {
        public UserGroupRepository(DBContext context) : base(context) { }

        public override IQueryable<UserGroup> Items => base.Items.Include(item => item.Achievements)
                                                                 .Include(item => item.Administrators)
                                                                 .Include(item => item.Creator)
                                                                 .Include(item => item.Users)
                                                                 .Include(item => item.GroupChat);
    }
}
