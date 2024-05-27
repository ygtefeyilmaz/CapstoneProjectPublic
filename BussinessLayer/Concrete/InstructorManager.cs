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
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _ınstructorDal;

        public InstructorManager(IInstructorDal ınstructorDal)
        {
            _ınstructorDal = ınstructorDal;
        }



        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _ınstructorDal.GetByIdAsync(id);
        }

        public void TAdd(Instructor t)
        {
            _ınstructorDal.Insert(t);
        }

        public async Task<int> TAddAsync(Instructor t)
        {
            return await _ınstructorDal.AddAsync(t);
        }

        public void TDelete(Instructor t)
        {
            _ınstructorDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Instructor t)
        {
            return await _ınstructorDal.DeleteAsync(t);
        }

        public Instructor TGetById(int id)
        {
            return _ınstructorDal.GetByID(id);
        }

        public List<Instructor> TGetList()
        {
            return _ınstructorDal.GetListAll();
        }

        public async Task<List<Instructor>> TGetListAllAsync()
        {
           return await _ınstructorDal.GetListAllAsync();
        }

        public void TUpdate(Instructor t)
        {
            _ınstructorDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Instructor t)
        {
            return await _ınstructorDal.UpdateAsync(t);
        }
    }
}
