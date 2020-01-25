﻿using Iris.Core.Base;
using Iris.Core.Databases.EntityFramework;
using Iris.DataAccessLayer.Abstract;
using Iris.DataAccessLayer.Contexts;
using Iris.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.DataAccessLayer.Concrete
{
    public class EfPersonDAL : EfRepositoryBase<DatabaseContext, Person>, IEfPersonDAL
    {
    }
}