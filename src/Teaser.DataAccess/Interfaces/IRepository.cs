using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teaser.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Get();
        T Save(T entity);
        bool Delete(T entity);
    }
}
