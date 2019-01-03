using System.Collections.Generic;

namespace QulixTestWork
{
    public interface IRepository<T>
    {
        List<T> Select();

        T SelectById(int id);

        List<Work> SelectWorksByImplementerId(int id);

        void Insert(T model);

        void Update(T model);

        void Delete(int id);
    }
}
