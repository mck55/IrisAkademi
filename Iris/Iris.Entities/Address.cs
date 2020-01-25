using Iris.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Entities
{
    public class Address : BaseEntity , IEntity
    {
        public string Description { get; set; } 
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } 
    }
}
