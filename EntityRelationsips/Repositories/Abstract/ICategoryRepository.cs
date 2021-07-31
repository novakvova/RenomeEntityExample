using MyLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
        void GetTreeCategory();
    }
}
