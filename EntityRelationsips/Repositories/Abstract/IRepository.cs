using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Repositories.Abstract
{
    public interface IRepository<T, K> where T : class
    {
        void Add(T item);
        T FindById(K id);
        IQueryable<T> Get(Func<T, bool> predicate);
    }
}
