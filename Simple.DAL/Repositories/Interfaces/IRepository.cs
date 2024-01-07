using Microsoft.EntityFrameworkCore;
using Simple.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? oredrByExpression = null,
            bool IsDescending = false,
            params string[] includes);
        DbSet<TEntity> Table { get; }

        Task Create(Cart cart);
        void Update(Cart cart);
        void Delete(Cart cart);

        Task Create(TEntity entity);
        Task<int> SaveChangesAsync();
        Task<Cart> GetByIdAsync(int id);
    }
}
