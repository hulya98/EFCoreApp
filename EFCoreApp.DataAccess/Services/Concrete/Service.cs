using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Concrete
{
    public class Service<T> 
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
