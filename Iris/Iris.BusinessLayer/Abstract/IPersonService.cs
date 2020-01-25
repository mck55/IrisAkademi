using Iris.Core.Base;
using Iris.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.BusinessLayer.Abstract
{
    public interface IPersonService :IRepository<Person>
    {
    }
}
