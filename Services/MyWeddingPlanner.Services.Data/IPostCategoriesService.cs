using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Services.Data
{
    public interface IPostCategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

    }
}
