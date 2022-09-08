using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreProject.Architecture.Data.Cache.Interfaces
{
    public interface ICacheService
    {
        Task<IEnumerable<T>> GetAllWithId<T>(string pattern = "*", Func<T, bool> filterFunction = null) where T : class;
        Task<IEnumerable<T>> GetAll<T>(string pattern = "*", Func<T, bool> filterFunction = null);
        Task<T> GetByKey<T>(string key);
        Task SetData<T>(string key, T value, DateTimeOffset expirationTime);
        Task RemoveData(string key);
    }
}
