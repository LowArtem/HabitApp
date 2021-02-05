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



        public async Task<int?> Create(int groupCreatorId, string name, string language = "en", ICollection<int> friendsIds = null)
        {
            if (string.IsNullOrEmpty(name)) return null;

            var groupCreator = await _users.GetAsync(groupCreatorId);

            if (groupCreator is null) return null;

            groupCreator.UserGroupStatus = "creator";
            await _users.UpdateAsync(groupCreator);

            var group = new UserGroup();
            var groupChat = new CreateChat(_chats, _users, _userGroup);

            group.Name = name;
            group.Language = language;
            group.CreationDate = DateTime.Now;
            group.Users.Add(groupCreator);

            // Adding creator's friends to group if creator wants
            if (friendsIds != null && friendsIds.Count > 0)
                foreach (int uId in friendsIds)
                {
                    var user = await _users.GetAsync(uId);
                    if (user is null) return null;

                    user.UserGroupStatus = "user";
                    await _users.UpdateAsync(user);

                    group.Users.Add(user);
                }
                        
            var new_group = await _userGroup.AddAsync(group);

            var chat_id = await groupChat.CreateGroupChat(groupCreatorId, new_group.Id, usersIds: friendsIds);

            if (chat_id is null) return null;

            return new_group.Id;
        }
    }
}
