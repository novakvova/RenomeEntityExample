using EntityRelationsips.Domain.Entities;
using EntityRelationsips.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
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
