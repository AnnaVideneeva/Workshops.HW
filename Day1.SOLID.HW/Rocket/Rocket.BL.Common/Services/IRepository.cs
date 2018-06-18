using System;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.DAL.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// get list of entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FetchAll();

        /// <summary>
        /// return TEntity by key
        /// </summary>
        TEntity GetElementById(int key);

        /// <summary>
        /// standart operation Add
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// standart operation Update
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// standart operation Delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}


