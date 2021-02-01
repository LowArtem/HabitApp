using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model.Interfaces
{
    internal class ChatRepository : DBRepository<Chat>
    {
        public ChatRepository(DBContext context) : base(context) { }

        public override IQueryable<Chat> Items => base.Items.Include(item => item.ChatMessages)
                                                            .Include(item => item.Users)
                                                            .Include(item => item.UserGroup);
    }
}
