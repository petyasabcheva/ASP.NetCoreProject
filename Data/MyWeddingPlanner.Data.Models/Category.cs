namespace MyWeddingPlanner.Data.Models
{
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

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
