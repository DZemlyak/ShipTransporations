using System.Collections.Generic;

namespace ShipTransportations.Model
{
    interface IRepository <T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        List<T> ReadAll();
        T GetItem(int id);
    }
}
