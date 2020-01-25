using Iris.Core.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Iris.Core.Databases.EntityFramework
{
    public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IEntity, new()
       where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.AtCreated = DateTime.Now;
                entity.IsDeleted = false;
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Delete(int id)
        {
            using (var context = new TContext())
            {
                TEntity ent =  context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                ent.IsDeleted = true;
                ent.AtDeleted = DateTime.Now;
                context.Update(ent);
                return ent;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            using (var context = new TContext())
            {
                return expression == null ?
                    context.Set<TEntity>().Where(x => !x.IsDeleted).ToList() :
                    context.Set<TEntity>().Where(x => !x.IsDeleted).Where(expression).ToList();
            }
        }

        public IQueryable<TEntity> GetListQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            using (var context = new TContext())
            {
                return expression == null ?
                    context.Set<TEntity>().Where(x => !x.IsDeleted) :
                    context.Set<TEntity>().Where(x => !x.IsDeleted).Where(expression);
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                TEntity ent = context.Set<TEntity>().Where(x => x.Id == entity.Id).FirstOrDefault();
                ent.AtModified = DateTime.Now;
                context.SaveChanges();
                return ent;
            }
        }
    }
}
