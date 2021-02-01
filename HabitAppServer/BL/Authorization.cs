using System.Linq;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;

namespace HabitAppServer.BL
{
    internal class Authorization
    {
        private readonly IRepository<User> _repository;

        public Authorization(IRepository<User> repository)
        {
            this._repository = repository;
        }

        public int? Authorizate(string login, string password)
        {
            var user = _repository.Items.SingleOrDefault(u => u.Login == login && u.Password == password);

            if (user is null) return null;

            return user.Id;
        }

        public async Task<int> Registrate(User user)
        {
            var new_user = await _repository.AddAsync(user);
            return new_user.Id;
        }
    }
}
