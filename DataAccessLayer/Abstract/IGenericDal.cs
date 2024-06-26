﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Update(T t); 
        void Delete(T t);
        List<T> GetListAll();
        T GetByID(int id);

        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T t);
        Task<int> UpdateAsync(T t);
        Task<int> DeleteAsync(T t);

       Task< List<T>> GetListAllAsync();
    }
}
