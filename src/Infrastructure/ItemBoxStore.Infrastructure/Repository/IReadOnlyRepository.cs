using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.Repository
{
    /// <summary>
    /// Интерфейс для репозитория - только чтение
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Возвращает все элементы сущности <see cref="TEntity"/>
        /// </summary>
        /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Возвращает все элементы сущности <see cref="TEntity"/> по предикату
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Все элементы сущности <see cref="TEntity"/> по предикату</returns>
        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Возвращает элемент сущности <see cref="TEntity"/> по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="TEntity"/></returns>
        ValueTask<TEntity> GetByIdAsync(Guid id);

    }
}
