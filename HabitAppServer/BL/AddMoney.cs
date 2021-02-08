using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    /// <summary>
    /// Добавляет указанное количество денег на счет указанного пользователя
    /// </summary>
    public class AddMoney
    {
        private readonly IRepository<User> users;

        public AddMoney(IRepository<User> users)
        {
            this.users = users;
        }

        public int? Add(long userId, int money)
        {
            var user = users.Get(userId);
            if (user is null) return null;

            user.Cash += money;

            if (user.Cash < 0) user.Cash = 0;

            users.Update(user);

            return user.Cash;
        }

        public static int? Add(long userId, int money, IRepository<User> users)
        {
            AddMoney addMoney = new AddMoney(users);

            return addMoney.Add(userId, money);
        }
    }
}
