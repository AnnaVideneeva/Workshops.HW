using Rocket.DAL.Common.Repositories;
using Rocket.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Rocket.DAL.Repositories
{
    /// <summary>
    /// Представляет обобщенный репозиторий.
    /// Код взят из статьи https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application.
    /// </summary>
    /// <typeparam name="TEntity">Тип, экземплярами которого управляет репозиторий.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly RocketContext _rocketContext;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Создает новый экземпляр репозитория с заданным контекстом базы данных.
        /// </summary>
        /// <param name="rocketContext">Экземпляр контекста базы данных.</param>
        public BaseRepository(RocketContext rocketContext)
        {
            _rocketContext = rocketContext;
            _dbSet = _rocketContext.Set<TEntity>();
        }

        /// <summary>
        /// Возвращает перечисление экземпляров <see cref="TEntity"/> из хранилища данных.
        /// Применяет фильтр, сортировку и загрузку связанных свойств,
        /// если заданы соответствующие значения параметров.
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтрацию экземпляров <see cref="TEntity"/>.</param>
        /// <param name="orderBy">Лямбда-выражение определяющее сортировку экземпляров <see cref="TEntity"/>.</param>
        /// <param name="includeProperties">Список связанных свойств экземпляров <see cref="TEntity"/>, разделенный запятыми.</param>
        /// <returns>Перечисление экземпляров <see cref="TEntity"/>.</returns>
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return GetFilteredQuery(filter, orderBy, includeProperties).ToList();
        }

        /// <summary>
        /// Возвращает страницу заданного размера с заданным номером
        /// в виде перечисления экземпляров <see cref="TEntity"/> из хранилища данных.
        /// Применяет фильтр, сортировку и загрузку связанных свойств,
        /// если заданы соответствующие значения параметров.
        /// </summary>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <param name="filter">Лямбда-выражение определяющее фильтрацию экземпляров <see cref="TEntity"/>.</param>
        /// <param name="orderBy">Лямбда-выражение определяющее сортировку экземпляров <see cref="TEntity"/>.</param>
        /// <param name="includeProperties">Список связанных свойств экземпляров <see cref="TEntity"/>, разделенный запятыми.</param>
        /// <returns>Перечисление экземпляров <see cref="TEntity"/>.</returns>
        public IEnumerable<TEntity> GetPage(
            int pageSize,
            int pageNumber,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = GetFilteredQuery(filter, orderBy, includeProperties);
            return query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        /// <summary>
        /// Возвращает экземпляр <see cref="TEntity"/>,
        /// соответствующий заданному идентификатору, из хранилища данных.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <typeparam name="TKey">Тип идентификатора.</typeparam>
        /// <returns>Экземпляр <see cref="TEntity"/>.</returns>
        public TEntity GetById<TKey>(TKey id)
        {
            return _dbSet.Find(id);
        }

        public virtual void SetStatusAdded(TEntity entity)
        {
            _rocketContext.Entry(entity).State = EntityState.Added;
        }

        public virtual void SetStatusAddedRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                SetStatusAdded(entity);
            }
        }

        public virtual void SetStatusNotModified(TEntity entity)
        {
            _rocketContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SetStatusNotModifiedRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                SetStatusNotModified(entity);
            }
        }

        /// <summary>
        /// Добавляет заданный экземпляр <see cref="TEntity"/> в хранилище данных.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _rocketContext.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Обновляет заданный экземпляр <see cref="TEntity"/> в хранилище данных.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _rocketContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Удаляет экземпляр <see cref="TEntity"/>,
        /// соответствующий заданному идентификатору, из хранилища данных.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <typeparam name="TKey">Тип идентификатора.</typeparam>
        public virtual void Delete<TKey>(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Удаляет заданный экземпляр <see cref="TEntity"/> из хранилища данных.
        /// </summary>
        /// <param name="entity">Экземпляр <see cref="TEntity"/>.</param>
        public virtual void Delete(TEntity entity)
        {
            if (_rocketContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Возвращает количество элементов в репозитории,
        /// соответствующих заданному фильтру.
        /// </summary>
        /// <param name="filter">Лямбда-выражение определяющее фильтрацию экземпляров <see cref="TEntity"/>.</param>
        /// <returns>Количество элементов.</returns>
        public int ItemsCount(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Count(filter);
            }

            return _dbSet.Count();
        }

        public virtual TEntity Find<TKey>(params TKey[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual IQueryable<TEntity> SelectQuery<TKey>(string query, params TKey[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public int SaveChanges()
        {
            return _rocketContext.SaveChanges();
        }

        private IQueryable<TEntity> GetFilteredQuery(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var includes = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
    }
}