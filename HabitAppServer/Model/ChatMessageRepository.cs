using System.Linq;
using HabitAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    internal class ChatMessageRepository : DBRepository<ChatMessage>
    {
        public ChatMessageRepository(DBContext context) : base(context) { }

        public override IQueryable<ChatMessage> Items => base.Items.Include(item => item.Chat)
                                                                   .Include(item => item.User);
    }
}
