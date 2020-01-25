using Iris.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Entities
{
    public class Person :BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Child> Childs { get; set; }

    }
}
