namespace MyWeddingPlanner.Services.Data
{
    using System.Collections.Generic;

    public interface IServicesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
