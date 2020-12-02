using System;
using System.Collections.Generic;
using System.Text;

using MyWeddingPlanner.Data.Common.Models;

namespace MyWeddingPlanner.Data.Models
{
    public abstract class Category<T> : BaseDeletableModel<int>
    {
        protected Category()
        {
            this.CategoryContents = new HashSet<T>();
        }

        public string Name { get; set; }

        public virtual ICollection<T> CategoryContents { get; set; }
    }
}
