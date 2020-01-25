using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Iris.Core.Base
{
    public interface IRepository<T> where T : BaseEntity, IEntity, new()
    {
        T Add(T entity);
        T Delete(int id);
        T Update(T entity); 
        List<T> GetList(Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetListQueryable(Expression<Func<T, bool>> expression = null);
    }
}
