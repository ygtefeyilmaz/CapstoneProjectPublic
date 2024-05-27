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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentDal.GetByIdAsync(id);
        }

        public void TAdd(Student t)
        {
            _studentDal.Insert(t);
        }

        public async Task<int> TAddAsync(Student t)
        {
            return await _studentDal.AddAsync(t);
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Student t)
        {
            return await _studentDal.DeleteAsync(t);
        }

        public Student TGetById(int id)
        {
            return _studentDal.GetByID(id);
        }

        public List<Student> TGetList()
        {
            return _studentDal.GetListAll();
        }

        public async Task<List<Student>> TGetListAllAsync()
        {
            return await _studentDal.GetListAllAsync();
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Student t)
        {
            return await _studentDal.UpdateAsync(t);
        }
    }
}
