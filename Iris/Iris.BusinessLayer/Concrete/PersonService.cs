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
    public class PersonService : IPersonService
    {
        private readonly IEfPersonDAL _personService;
        public PersonService(IEfPersonDAL personService)
        {
            _personService = personService;
        }
        public Person Add(Person entity)
        {
            return _personService.Add(entity);
        }

        public Person Delete(int id)
        {
            return _personService.Delete(id);
        }

        public List<Person> GetList(Expression<Func<Person, bool>> expression = null)
        {
            return _personService.GetList(expression);
        }

        public IQueryable<Person> GetListQueryable(Expression<Func<Person, bool>> expression = null)
        {
            return _personService.GetListQueryable(expression);
        }

        public Person Update(Person entity)
        {
            return _personService.Update(entity);
        }
    }
}
