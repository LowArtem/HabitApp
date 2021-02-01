using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HabitAppServer.Model.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория, управляющего моделями данных
    /// </summary>
    /// <typeparam name="T">класс модели данных</typeparam>
    internal interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken cancel = default);

        void Update(T item);
        Task UpdateAsync(T item, CancellationToken cancel = default);

        T Remove(int id);
        Task<T> RemoveAsync(int id, CancellationToken cancel = default);
    }
}
