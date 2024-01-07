using Microsoft.EntityFrameworkCore;
using Simple.Core.Entities;
using Simple.DAL.Context;
using Simple.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DAL.Repositories.Implimetations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();



        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? oredrByExpression = null,
            bool IsDescending = false,
            params string[] includes)
        {
            IQueryable<TEntity> query = Table;
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (oredrByExpression != null)
            {
                query = IsDescending ? query.OrderByDescending(oredrByExpression) :
                    query.OrderBy(oredrByExpression);
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task Create(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }

        public void Delete(Cart cart)
        {
            _context?.Carts.Remove(cart);
        }

       
        

    }
}
