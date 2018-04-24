using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITodoRepository
    {
        Task<int> Add(Todo todo);
        Task<Todo> Get(int id);
        Task<IEnumerable<Todo>> List();
        Task<bool> Delete(int id);
        Task<bool> Update(Todo todo);
    }
}
