namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;

    public interface IItemsCategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
