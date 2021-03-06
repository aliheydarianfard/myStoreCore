﻿using Ahf.Core.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahf.Core.Domain
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public int? ParentId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Product> Products  { get; set; }


    }
}
