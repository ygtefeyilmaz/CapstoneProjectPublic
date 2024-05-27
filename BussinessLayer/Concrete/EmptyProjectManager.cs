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
    public class EmptyProjectManager : IEmptyProjectService
    {
        private readonly IEmptyProjectDal _emptyProjectDal;

        public EmptyProjectManager(IEmptyProjectDal emptyProjectDal)
        {
            _emptyProjectDal = emptyProjectDal;
        }
         
        public async Task<EmptyProject> GetByIdAsync(int id)
        {
            return await _emptyProjectDal.GetByIdAsync(id);
        }

        public List<EmptyProject> GetContactList()
        {
            return _emptyProjectDal.GetContactList();
        }

        public void TAdd(EmptyProject t)
        {
            _emptyProjectDal.Insert(t);
        }

        public async Task<int> TAddAsync(EmptyProject t)
        {
            return await _emptyProjectDal.AddAsync(t);
        }

        public void TDelete(EmptyProject t)
        {
            _emptyProjectDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(EmptyProject t)
        {
            return await _emptyProjectDal.DeleteAsync(t);
        }

        public EmptyProject TGetById(int id)
        {
            return _emptyProjectDal.GetByID(id);
        }

        public List<EmptyProject> TGetList()
        {
            return _emptyProjectDal.GetListAll();
        }

        public async Task<List<EmptyProject>> TGetListAllAsync()
        {
            return await _emptyProjectDal.GetListAllAsync();
        }

        public void TUpdate(EmptyProject t)
        {
            _emptyProjectDal.Update(t);
        }

        public async Task<int> TUpdateAsync(EmptyProject t)
        {
            return await _emptyProjectDal.UpdateAsync(t);
        }







    }
}
