using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.API.Repository
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public Task<T> Update(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<bool> Delete(Guid item_id);
    }
}
