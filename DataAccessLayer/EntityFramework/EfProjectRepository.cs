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
    public class EfProjectRepository : GenericRepository<Project>, IProjectDal
    {
        public List<Project> GetContactList()
        {
            using (var c = new Context())
            {
                var genelList = new List<Project>(c.Projects.Include(x => x.Department))
                        .Concat(new List<Project>(c.Projects.Include(y => y.Instructor)))
                        .Distinct().ToList();
                return genelList;
            }

        }
    }
}
