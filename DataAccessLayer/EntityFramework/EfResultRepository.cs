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
    public class EfResultRepository : GenericRepository<Result>, IResultDal
    {
        public List<Result> GetContactList()
        {
            using (var c = new Context())
            {
                var genelList = new List<Result>(c.Results.Include(x => x.Team))
                        .Concat(new List<Result>(c.Results.Include(y => y.Project)))
                        .Distinct().ToList();
                return genelList;
            }

        }
    }
}
