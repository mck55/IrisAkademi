using Iris.BusinessLayer.Abstract;
using Iris.DataAccessLayer.Abstract;
using Iris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Iris.BusinessLayer.Concrete
{
    public class ChildService : IChildService
    {
        private readonly IEfChildDAL _childService;
        public ChildService(IEfChildDAL childService)
        {
            _childService = childService;
        }
        public Child Add(Child entity)
        {
            return _childService.Add(entity);
        }

        public Child Delete(int id)
        {
            return _childService.Delete(id);
        }

        public List<Child> GetList(Expression<Func<Child, bool>> expression = null)
        {
            return _childService.GetList(expression);
        }

        public IQueryable<Child> GetListQueryable(Expression<Func<Child, bool>> expression = null)
        {
            return _childService.GetListQueryable(expression);
        }

        public Child Update(Child entity)
        {
            return _childService.Update(entity);
        }
    }
}
