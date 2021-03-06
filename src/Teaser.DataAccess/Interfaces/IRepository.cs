﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teaser.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Save(T entity);
        bool Delete(T entity);
    }
}
