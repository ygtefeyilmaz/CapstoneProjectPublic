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
    public class GeneralNeedsManager : IGeneralNeedsService
    {
        private readonly IGeneralNeedsDal _generalNeedsDal;

        public GeneralNeedsManager(IGeneralNeedsDal generalNeedsDal)
        {
            _generalNeedsDal = generalNeedsDal;
        }
         

        public async Task<GeneralNeeds> GetByIdAsync(int id)
        {
            return await _generalNeedsDal.GetByIdAsync(id);
        }

        public void TAdd(GeneralNeeds t)
        {
            _generalNeedsDal.Insert(t);
        }

        public async Task<int> TAddAsync(GeneralNeeds t)
        {
            return await _generalNeedsDal.AddAsync(t);
        }

        public void TDelete(GeneralNeeds t)
        {
            _generalNeedsDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(GeneralNeeds t)
        {
            return await _generalNeedsDal.DeleteAsync(t);
        }

        public GeneralNeeds TGetById(int id)
        {
            return _generalNeedsDal.GetByID(id);
        }

        public List<GeneralNeeds> TGetList()
        {
            return _generalNeedsDal.GetListAll();
        }

        public async Task<List<GeneralNeeds>> TGetListAllAsync()
        {
           return await _generalNeedsDal.GetListAllAsync();
        }

        public void TUpdate(GeneralNeeds t)
        {
            _generalNeedsDal.Update(t);
        }

        public async Task<int> TUpdateAsync(GeneralNeeds t)
        {
            return await _generalNeedsDal.UpdateAsync(t);
        }
    }
}
