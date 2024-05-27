using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfEmptyProjectRepository : GenericRepository<EmptyProject>, IEmptyProjectDal
    {
        public List<EmptyProject> GetContactList()
        {
            using (var c = new Context())
            {
                var genelList = new List<EmptyProject>(c.EmptyProjects.Include(x => x.Project))
                         .Distinct().ToList();
                return genelList;
            }

        }
    }
}
