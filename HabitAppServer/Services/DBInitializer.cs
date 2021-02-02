using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;

namespace HabitAppServer.Services
{
    /// <summary>
    /// Класс для первичной инициализации БД
    /// </summary>
    public static class DBInitializer
    {
        public static void Initialize(DBContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Username = "Username1",
                        Login = "Login1",
                        Password = "Password1",
                        RegistrationDate = DateTime.Now
                    },
                    new User
                    {
                        Username = "Usernam21",
                        Login = "Login2",
                        Password = "Password2",
                        RegistrationDate = DateTime.Now
                    },
                    new User
                    {
                        Username = "Username3",
                        Login = "Login3",
                        Password = "Password3",
                        RegistrationDate = DateTime.Now
                    },
                    new User
                    {
                        Username = "Username4",
                        Login = "Login4",
                        Password = "Password4",
                        RegistrationDate = DateTime.Now
                    },
                    new User
                    {
                        Username = "Username5",
                        Login = "Login5",
                        Password = "Password5",
                        RegistrationDate = DateTime.Now
                    }
                    );
                context.SaveChanges();


                context.Rewards.AddRange(
                    new Reward
                    {
                        Category = "Category1",
                        Description = "Description1"
                    },
                    new Reward
                    {
                        Category = "Category2",
                        Description = "Description2"
                    },
                    new Reward
                    {
                        Category = "Category3",
                        Description = "Description3"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
