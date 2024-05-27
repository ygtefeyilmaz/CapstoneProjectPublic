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
    public class GraphManager : IGraphService
    {
        private readonly IGraphDal _graphDal;

        public GraphManager(IGraphDal graphDal)
        {
            _graphDal = graphDal;
        }


         

        public async Task<Graph> GetByIdAsync(int id)
        {
            return await _graphDal.GetByIdAsync(id);
        }

        public void TAdd(Graph t)
        {
            _graphDal.Insert(t);
        }

        public async Task<int> TAddAsync(Graph t)
        {
            return await _graphDal.AddAsync(t);
        }

        public void TDelete(Graph t)
        {
            _graphDal.Delete(t);
        }

        public async Task<int> TDeleteAsync(Graph t)
        {
            return await _graphDal.DeleteAsync(t);
        }

        public Graph TGetById(int id)
        {
            return _graphDal.GetByID(id);
        }

        public List<Graph> TGetList()
        {
            return _graphDal.GetListAll();
        }

        public async Task<List<Graph>> TGetListAllAsync()
        {
            return await _graphDal.GetListAllAsync();
        }

        public void TUpdate(Graph t)
        {
            _graphDal.Update(t);
        }

        public async Task<int> TUpdateAsync(Graph t)
        {
            return await _graphDal.UpdateAsync(t);
        }






    }
}
