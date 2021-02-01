﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HabitAppServer.Data;
using HabitAppServer.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HabitAppServer.Model
{
    /// <summary>
    /// Класс для управления моделями данных
    /// </summary>
    /// <typeparam name="T">класс модели данных</typeparam>
    internal class DBRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>Автоматически сохранять изменения в базе данных</summary>
        public bool AutoSaveChanges { get; set; } = true;


        private readonly DBContext _context;
        private readonly DbSet<T> _Set;


        public DBRepository(DBContext context)
        {
            this._context = context;
            _Set = context.Set<T>();
        }


        /// <summary>Коллекция элементов</summary>
        public virtual IQueryable<T> Items => _Set;


        /// <summary>
        /// Добавляем данные
        /// </summary>
        /// <param name="item"></param>
        /// <returns>добавленный объект</returns>
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _context.SaveChanges();

            return item;
        }

        /// <summary>
        /// Добавляем данные асинхронно
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancel">токен отмены</param>
        /// <returns>добавленный объект</returns>
        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

            return item;
        }

        /// <summary>
        /// Получаем данные
        /// </summary>
        /// <param name="id"></param>
        /// <returns>полученный объект (или null)</returns>
        public T Get(int id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Получаем данные асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel">токен отмены</param>
        /// <returns>полученный объект (или null)</returns>
        public async Task<T> GetAsync(int id, CancellationToken cancel = default)
        {
            return await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);
        }

        /// <summary>
        /// Удаляем данные
        /// </summary>
        /// <param name="id"></param>
        /// <returns>удаленный объект</returns>
        public T Remove(int id)
        {
            var item = Get(id);
            if (item is null) return null;

            _context.Remove(item);

            if (AutoSaveChanges)
                _context.SaveChanges();

            return item;
        }

        /// <summary>
        /// Удаляем данные асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel">токен отмены</param>
        /// <returns>удаленный объект</returns>
        public async Task<T> RemoveAsync(int id, CancellationToken cancel = default)
        {
            var item = await GetAsync(id);
            if (item is null) return null;

            _context.Remove(item);

            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

            return item;
        }

        /// <summary>
        /// Обновляем данные
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        /// <summary>
        /// Обновляем данные асинхронно
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
