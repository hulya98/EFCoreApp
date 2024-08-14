using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Repositories.Abstract
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
