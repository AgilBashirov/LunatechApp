using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Persistence.Infrastructure
{
    public abstract class BaseRepo<TEntity> : Repository<TEntity> where TEntity : BaseEntity
    {
        protected BaseRepo(AppDbContext context) : base(context)
        {
        }
    }
}
