using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<int> TAddAsync(T t);
        Task<int> TUpdateAsync(T t);
        Task<int> TDeleteAsync(T t);

        Task<List<T>> TGetListAllAsync();
    }
}
