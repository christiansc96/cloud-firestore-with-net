using System.Collections.Generic;

namespace cloud_firestore_with_net.Repositories
{
    public interface IFirestoreRepository<T>
    {
        T Add(T model);
        bool Delete(T model);
        T Get(T model);
        List<T> GetAll();
        bool Update(T model);
    }
}