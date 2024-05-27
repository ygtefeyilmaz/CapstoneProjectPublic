using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IEmptyProjectService : IGenericService<EmptyProject>
    {
        List<EmptyProject> GetContactList();
    }
}
