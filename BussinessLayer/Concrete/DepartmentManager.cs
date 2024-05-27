using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
         


        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentDal.GetByIdAsync(id);
        }

        public void TAdd(Department t)
        {
            _departmentDal.Insert(t);
        }

        public async Task<int> TAddAsync(Department t)
        {
            return await _departmentDal.AddAsync(t);
        }

        public void TDelete(Department t)
        {
            _departmentDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Department t)
        {
            return await _departmentDal.DeleteAsync(t);
        }

        public Department TGetById(int id)
        {
            return _departmentDal.GetByID(id);
        }

        public List<Department> TGetList()
        {
           return _departmentDal.GetListAll();
        }

        public async Task<List<Department>> TGetListAllAsync()
        {
            return await _departmentDal.GetListAllAsync();
        }
         
        public void TUpdate(Department t)
        {
            _departmentDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Department t)
        {
            return await _departmentDal.UpdateAsync(t);
        }

    }
}
