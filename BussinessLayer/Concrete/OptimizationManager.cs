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
    public class OptimizationManager : IOptimizationService
    {
        private readonly IOptimizationDal _optimizationDal;

        public OptimizationManager(IOptimizationDal optimizationDal)
        {
            _optimizationDal = optimizationDal;
        }
         

        public async Task<Optimization> GetByIdAsync(int id)
        {
            return await _optimizationDal.GetByIdAsync(id);
        }

        public void TAdd(Optimization t)
        {
            _optimizationDal.Insert(t);
        }

        public async Task<int> TAddAsync(Optimization t)
        {
            return await _optimizationDal.AddAsync(t);
        }

        public void TDelete(Optimization t)
        {
            _optimizationDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Optimization t)
        {
            return await _optimizationDal.DeleteAsync(t);
        }

        public Optimization TGetById(int id)
        {
            return _optimizationDal.GetByID(id);
        }

        public List<Optimization> TGetList()
        {
            return _optimizationDal.GetListAll();
        }

        public async Task<List<Optimization>> TGetListAllAsync()
        {
            return await _optimizationDal.GetListAllAsync();
        }

        public void TUpdate(Optimization t)
        {
            _optimizationDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Optimization t)
        {
            return await _optimizationDal.UpdateAsync(t);
        }
    } 
}
