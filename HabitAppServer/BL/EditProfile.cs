using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    public class EditProfile
    {
        private readonly IRepository<User> _repository;

        public EditProfile(IRepository<User> repository)
        {
            this._repository = repository;
        }

        public async Task<User> Edit(int id, string description = null, byte[] avatar = null, string username = null)
        {
            if (_repository.Get(id) == null) return null;

            if (username != null && _repository.Items.Any(u => u.Username.ToLower() == username.ToLower() && u.Id != id)) return null;

            _repository.AutoSaveChanges = false;

            var user = await _repository.GetAsync(id);

            if (!string.IsNullOrEmpty(description))
            {
                user.Description = description;
                await _repository.UpdateAsync(user);
            }

            if (!string.IsNullOrEmpty(username))
            {
                user.Username = username;
                await _repository.UpdateAsync(user);
            }

            if (avatar != null && avatar.Count() != 0)
            {
                user.Avatar = avatar;
                await _repository.UpdateAsync(user);
            }

            await _repository.SaveChangesAsync();

            return user;
        }

        public async Task<int?> DeleteUserAccount(int userId, string login, string password, IRepository<Achievement> achievementsRepo,
            IRepository<Reward> rewardsRepo, IRepository<UserGroup> usergroupsRepo, IRepository<Chat> chatsRepo, 
            IRepository<ChatMessage> chatmsgRepo)
        {
            var user = await _repository.GetAsync(userId);
            if (user is null) return null;

            if (user.Login != login || user.Password != password) return null;

            user.Habits.Clear();

            foreach (var achievement in user.Achievements)
            {
                achievement.Users.Remove(user);
                await achievementsRepo.UpdateAsync(achievement);
            }

            foreach (var reward in user.Rewards)
            {
                reward.Users.Remove(user);
                await rewardsRepo.UpdateAsync(reward);
            }

            foreach (var chat in user.Chats)
            {
                chat.Users.Remove(user);

                if (chat.Users.Count > 1 || (chat.UserGroup != null && chat.UserGroup.Users.Count > 0))
                    await chatsRepo.UpdateAsync(chat);
                else
                    await chatsRepo.RemoveAsync(chat.Id);
            }

            var usergroup = user.UserGroup;
            usergroup.Users.Remove(user);
            await usergroupsRepo.UpdateAsync(usergroup);

            foreach (var msg in user.ChatMessages)
            {
                await chatmsgRepo.RemoveAsync(msg.Id);
            }

            await _repository.RemoveAsync(user.Id);

            return user.Id;
        }
    }
}
