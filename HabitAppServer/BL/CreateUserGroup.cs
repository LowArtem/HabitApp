using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    public class CreateUserGroup
    {
        private readonly IRepository<User> _users;
        private readonly IRepository<UserGroup> _userGroup;
        private readonly IRepository<Chat> _chats;

        public CreateUserGroup(IRepository<User> users, IRepository<UserGroup> userGroup, IRepository<Chat> chats)
        {
            this._users = users;
            this._userGroup = userGroup;
            this._chats = chats;
        }

        // TODO: протестировать этот код

        public async Task<int?> Create(int groupCreatorId, string name, string language = "en", ICollection<int> friendsIds = null)
        {
            if (string.IsNullOrEmpty(name)) return null;

            var groupCreator = await _users.GetAsync(groupCreatorId);

            if (groupCreator is null) return null;

            groupCreator.UserGroupStatus = "creator";
            await _users.UpdateAsync(groupCreator);

            var group = new UserGroup();

            group.Name = name;
            group.Language = language;
            group.CreationDate = DateTime.Now;
            group.Users.Add(groupCreator);
                        
            var new_group = await _userGroup.AddAsync(group);

            var groupChat = new CreateChat(_chats, _users, _userGroup);
            var chat_id = await groupChat.CreateGroupChat(groupCreatorId, new_group.Id);

            if (chat_id is null) return null;

            return new_group.Id;
        }
    }
}
