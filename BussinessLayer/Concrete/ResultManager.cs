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
    public class ResultManager : IResultService
    {
        private readonly IResultDal _resultDal;

        public ResultManager(IResultDal resultDal)
        {
            _resultDal = resultDal;
        }




        public async Task<Result> GetByIdAsync(int id)
        {
            return await _resultDal.GetByIdAsync(id);
        }

        public List<Result> GetContactList()
        {
          return _resultDal.GetContactList();
        }

        public void TAdd(Result t)
        {
            _resultDal.Insert(t);
        }

        public async Task<int> TAddAsync(Result t)
        {
            return await _resultDal.AddAsync(t);
        }

        public void TDelete(Result t)
        {
            _resultDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Result t)
        {
            return await _resultDal.DeleteAsync(t);
        }

        public Result TGetById(int id)
        {
            return _resultDal.GetByID(id);
        }

        public List<Result> TGetList()
        {
            return _resultDal.GetListAll();
        }

        public async Task<List<Result>> TGetListAllAsync()
        {
          return await _resultDal.GetListAllAsync();
        }

        public void TUpdate(Result t)
        {
            _resultDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Result t)
        {
            return await _resultDal.UpdateAsync(t);
        }
    }
}
