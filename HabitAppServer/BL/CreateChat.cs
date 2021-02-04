using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    public class CreateChat
    {
        private readonly IRepository<Chat> _chats;
        private readonly IRepository<User> _users;
        private readonly IRepository<UserGroup> _groups;

        public CreateChat(IRepository<Chat> chats, IRepository<User> users, IRepository<UserGroup> groups)
        {
            this._chats = chats;
            this._users = users;
            this._groups = groups;
        }



        public async Task<int?> CreateGroupChat(int groupCreatorId, int groupId, string name = "")
        {
            var groupCreator = await _users.GetAsync(groupCreatorId);
            var group = await _groups.GetAsync(groupId);

            if (group is null || groupCreator is null) return null;

            Chat chat = new Chat();

            if (string.IsNullOrEmpty(name))
                name = $"{group.Name} Chat";

            chat.Name = name;
            chat.UserGroup = group;
            chat.Users.Add(groupCreator);

            var new_chat = await _chats.AddAsync(chat);

            return new_chat.Id;
        }

        public async Task<int?> CreatePrivateChat(int first_user_id, int second_user_id)
        {
            var first_user = await _users.GetAsync(first_user_id);
            var second_user = await _users.GetAsync(second_user_id);

            if (first_user is null || second_user is null || first_user_id == second_user_id) return null;

            Chat chat = new Chat();

            string name = $"{first_user.Username} {second_user.Username} Chat";

            chat.Name = name;
            chat.Users.Add(first_user);
            chat.Users.Add(second_user);

            var new_chat = await _chats.AddAsync(chat);

            return new_chat.Id;
        }
    }
}
