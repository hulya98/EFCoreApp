using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Abstract
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
