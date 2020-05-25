using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Data
{
    public class RetrieverRepository : IRetrieverRepository
    {
        private readonly ApplicationDbContext _context;

        public RetrieverRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties ??= string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();


            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,int? skip = null,int? take = null)where TEntity : class
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById<TEntity>(object id)
            where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }

        public TEntity LoadRecursive<TEntity>(TEntity entity,
            Expression<Func<TEntity, IEnumerable<TEntity>>> loadSelector,
            string includeProperties)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            _context.Entry(entity)
                .Collection(loadSelector)
                .Load();

            Travers(entity);
            foreach (var child in loadSelector.Compile().Invoke(entity))
                LoadRecursive<TEntity>(child, loadSelector, includeProperties);
            return entity;
        }


        private void Travers(object entity)
        {
            var entry = _context.Entry(entity);
            foreach (var entryNavigation in entry.Navigations)
            {
                entryNavigation.Load();
            }

            foreach (var entryReference in entry.References)
            {
                entryReference.Load();
            }

            foreach (var entryCollection in entry.Collections)
            {
                entryCollection.Load();
            }
        }
    }
}