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
    public class AddressService : IAddressService
    {
        private readonly IEfAddressDAL _adressService;
        public AddressService(IEfAddressDAL adressService)
        {
            _adressService = adressService;
        }
        public Address Add(Address entity)
        {
            return _adressService.Add(entity);
        }

        public Address Delete(int id)
        {
            return _adressService.Delete(id);
        }

        public List<Address> GetList(Expression<Func<Address, bool>> expression = null)
        {
            return _adressService.GetList(expression);
        }

        public IQueryable<Address> GetListQueryable(Expression<Func<Address, bool>> expression = null)
        {
            return _adressService.GetListQueryable(expression);
        }

        public Address Update(Address entity)
        {
            return _adressService.Update(entity);
        }
    }
}
