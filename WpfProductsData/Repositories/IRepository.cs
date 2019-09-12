using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProdutcs.Models;

namespace WpfProductsData.Repositories
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        IQueryable<T> Get();
        T Get(int id);
        T Save(T entity);
        void Delete(int id);
    }
}
