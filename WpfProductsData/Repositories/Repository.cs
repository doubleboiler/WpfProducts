using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProdutcs.Models;

namespace WpfProductsData.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly ProductContext _productContext;

        public Repository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public void Delete(int id)
        {
            var databaseEntity = Get(id);
            if (databaseEntity == null)
            {
                throw new InvalidOperationException("Этой сущности нет в БД");
            }
            _productContext.Set<T>().Remove(databaseEntity);
            _productContext.SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return _productContext.Set<T>();
        }

        public T Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }
        private T SaveNew(T entity)
        {
            _productContext.Set<T>().Add(entity);
            _productContext.SaveChanges();
            return entity;
        }

        public T Save(T entity)
        {
            if (entity.Id == 0)
            {
                return SaveNew(entity);
            }
            var databaseEntity = Get(entity.Id);
            _productContext.Entry(databaseEntity).CurrentValues.SetValues(entity);
            _productContext.SaveChanges();
            return entity;
        }
    }
}
