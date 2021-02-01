using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model.Interfaces
{
    internal class UserRepository : DBRepository<User>
    {
        public UserRepository(DBContext context) : base(context) { }

        public override IQueryable<User> Items => base.Items.Include(item => item.Achievements)
                                                            .Include(item => item.Chats)
                                                            .Include(item => item.Habits)
                                                            .Include(item => item.ChatMessages)
                                                            .Include(item => item.Rewards)
                                                            .Include(item => item.UserGroups);
    }
}
