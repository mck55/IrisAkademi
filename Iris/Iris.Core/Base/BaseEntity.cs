using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Iris.Core.Base
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime AtCreated { get; set; }
        public DateTime? AtDeleted { get; set; }
        public DateTime? AtModified { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreateUser { get; set; }

    }
}
