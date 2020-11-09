using System;
using System.Threading.Tasks;

namespace MyWeddingPlanner.Data.Common
{
    public interface IDbQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
