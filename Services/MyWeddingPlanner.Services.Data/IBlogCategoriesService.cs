using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Services.Data
{
    public interface IBlogCategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
