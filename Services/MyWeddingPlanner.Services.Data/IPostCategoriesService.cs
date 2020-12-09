namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPostCategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
