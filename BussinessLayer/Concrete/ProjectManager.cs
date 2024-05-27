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
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }





        public async Task<Project> GetByIdAsync(int id)
        {
            return await _projectDal.GetByIdAsync(id);
        }

        public List<Project> GetContactList()
        {
           return _projectDal.GetContactList();
        }

        public void TAdd(Project t)
        {
            _projectDal.Insert(t);
        }

        public async Task<int> TAddAsync(Project t)
        {
            return await _projectDal.AddAsync(t);
        }

        public void TDelete(Project t)
        {
            _projectDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Project t)
        {
            return await _projectDal.DeleteAsync(t);
        }

        public Project TGetById(int id)
        {
            return _projectDal.GetByID(id);
        }

        public List<Project> TGetList()
        {
            return _projectDal.GetListAll();
        }

        public async Task<List<Project>> TGetListAllAsync()
        {
           return await _projectDal.GetListAllAsync();  
        }

        public void TUpdate(Project t)
        {
            _projectDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Project t)
        {
            return await _projectDal.UpdateAsync(t);
        }
    }
}
