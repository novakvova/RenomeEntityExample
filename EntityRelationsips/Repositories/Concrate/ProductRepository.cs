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
    public class ProductRepository : Repository<Product, long>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
    }
}
