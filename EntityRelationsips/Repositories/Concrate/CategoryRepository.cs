using EntityRelationsips.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using MyLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Repositories.Concrate
{
    public class CategoryRepository : Repository<Category, long>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }

        public void GetTreeCategory()
        {
            throw new NotImplementedException();
        }
    }
}
