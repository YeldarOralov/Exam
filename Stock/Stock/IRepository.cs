﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
