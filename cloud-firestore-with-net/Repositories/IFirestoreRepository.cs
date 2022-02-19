using System.Collections.Generic;

namespace cloud_firestore_with_net.Repositories
{
    public interface IFirestoreRepository<T>
    {
        T Get(T record);
    }
}