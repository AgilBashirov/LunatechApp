using Lunatech.Application.Services.Abstraction;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lunatech.Persistence.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly AppDbContext _context;
        private DbSet<TEntity> Table => _context.Set<TEntity>();
        private DatabaseFacade Database => _context.Database;
        private IDbContextTransaction Transaction => Database.CurrentTransaction;

        public Repository(AppDbContext context)
            => _context = context;

        public virtual IQueryable<TEntity> AsQueryable(bool includeActive = true) =>
            AddDeletedFilter(Table, !includeActive);

        protected virtual IQueryable<TEntity> AddDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            query = query.Where(x => x.IsActive);

            return query;
        }

        private async Task<int> SaveChangesAsync(bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (saveChanges)
                return await _context.SaveChangesAsync(cancellationToken);

            return default;
        }


        public async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true) =>
            await GetAllQuery(func, includeDeleted).ToListAsync();

        public IQueryable<TEntity> GetAllQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table.AsQueryable(), includeDeleted);
            query = func != null ? func(query) : query;

            return query;
        }

        public Task<TEntity> GetByIdAsync(int? id, bool includeDeleted = true)
        {
            if (!id.HasValue || id == 0)
                return null;

            async Task<TEntity> getEntityAsync()
            {
                return await AddDeletedFilter(Table, includeDeleted)
                    .FirstOrDefaultAsync(entity => entity.Id == id.Value);
            }

            return getEntityAsync();
        }


        public async Task<IList<TEntity>> GetByIdsAsync(IList<int> ids, bool includeDeleted = true)
        {
            if (!ids?.Any() ?? true)
                return new List<TEntity>();

            async Task<IList<TEntity>> getByIdsAsync()
            {
                var query = AddDeletedFilter(Table, includeDeleted);

                //get entries
                var entries = await query.Where(entry => ids.Contains(entry.Id)).ToListAsync();

                //sort by passed identifiers
                var sortedEntries = new List<TEntity>();
                foreach (var id in ids)
                {
                    var sortedEntry = entries.FirstOrDefault(entry => entry.Id == id);
                    if (sortedEntry != null)
                        sortedEntries.Add(sortedEntry);
                }

                return sortedEntries;
            }

            return await getByIdsAsync();
        }


        public async Task<int> InsertAsync(TEntity entity, bool saveChanges = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }


        public async Task<int> UpdateAsync(TEntity entity)
         {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            switch (_context.Entry(entity).State)
            {
                case EntityState.Added:
                case EntityState.Deleted:
                    throw new InvalidOperationException("EntityState not valid for update");

                case EntityState.Detached:
                    entity.UpdateDate = DateTime.Now;
                    Table.Update(entity);
                    //entity.IsActive = true;
                    break;

                case EntityState.Unchanged:
                case EntityState.Modified:
                    break;

                default:
                    throw new InvalidOperationException("EntityState has not value");
            }

            await _context.SaveChangesAsync();

            return entity.Id;
        }
     

        public async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            //switch (entity)
            //{
            //    case null:
            //        throw new ArgumentNullException(nameof(entity));

            //    case IActive softDeletedEntity:
            //        softDeletedEntity.IsActive = false;
            //        await UpdateAsync(entity, saveChanges);
            //        break;
            //}

            if (entity is null) {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
                entity.IsActive = false;
                entity.DeletedDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                Table.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
