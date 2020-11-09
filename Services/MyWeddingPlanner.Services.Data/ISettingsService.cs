using System.Collections.Generic;

namespace MyWeddingPlanner.Services.Data
{
    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
