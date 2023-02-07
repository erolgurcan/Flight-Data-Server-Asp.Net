using flight_data_server.Models.Airliner;
using System.Linq.Expressions;

namespace flight_data_server.Interface
    {
    public interface IDatabaseFunctions<T> where T : class
        {

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T airliner);
        Task RemoveAsync(T airliner);
        Task SaveAsync();
        }
    }
