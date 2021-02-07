﻿using System;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    public class Authorization
    {
        private readonly IRepository<User> _repository;

        public Authorization(IRepository<User> repository)
        {
            this._repository = repository;
        }

        public long? Authorizate(string login, string password)
        {
            var user = _repository.Items.SingleOrDefault(u => u.Login == login && u.Password == password);

            if (user is null) return null;

            return user.Id;
        }

        public async Task<long?> RegistrateAsync(User user)
        {
            if (_repository.Items.Any(u => user.Id != 0 || u.Login == user.Login || u.Username == user.Username))
                return null;

            user.RegistrationDate = DateTime.Now;
            var new_user = await _repository.AddAsync(user);
            return new_user.Id;
        }

        public async Task<User> GetUserAsync(long id)
        {
            var user = await _repository.GetAsync(id);

            return user;
        }
    }
}
