using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleHelper.Data
{
    public interface IDataAccess<T>
    {
        public Task Insert(T entity);
        public Task Update(T entity);
        public Task<T> GetByName(string id);
        public Task Delete(string id);
        public Task<IEnumerable<T>> GetAll();
        public Task InsertMany (IEnumerable<T> entities);
    }
}
