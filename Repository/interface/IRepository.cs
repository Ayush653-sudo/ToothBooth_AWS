using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tooth_Booth_API.Repository
{
    public interface IRepository<T,k> where T : class
    {
        Task<IEnumerable<T>> GetAll(string node);
        Task AddAsync(T entity);

        Task Update(T entity);

        Task DeleteAsync(string node , k id);


    }
}
