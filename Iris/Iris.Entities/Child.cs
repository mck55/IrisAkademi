using Iris.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Entities
{
    public class Child:BaseEntity , IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int PersonId { get; set; }
        public virtual Person  Person { get; set; }

    }
}
