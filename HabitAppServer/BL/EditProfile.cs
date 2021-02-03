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
    }
}
