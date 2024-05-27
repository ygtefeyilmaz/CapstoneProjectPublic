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
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal  _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _teamDal.GetByIdAsync(id);
        }

        public void TAdd(Team t)
        {
            _teamDal.Insert(t);
        }

        public async Task<int> TAddAsync(Team t)
        {
            return await _teamDal.AddAsync(t);
        }

        public void TDelete(Team t)
        {
            _teamDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Team t)
        {
            return await _teamDal.DeleteAsync(t);
        }

        public Team TGetById(int id)
        {
            return _teamDal.GetByID(id);
        }

        public List<Team> TGetList()
        {
            return _teamDal.GetListAll();
        }

        public async Task<List<Team>> TGetListAllAsync()
        {
            return await _teamDal.GetListAllAsync();
        }

        public void TUpdate(Team t)
        {
            _teamDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Team t)
        {
            return await _teamDal.UpdateAsync(t);
        }

    }
}
