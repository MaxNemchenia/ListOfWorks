using System.Collections.Generic;

namespace QulixTestWork
{
    public interface IService<T>
    {
        List<T> getAll();

        T getById(int id);

        List<Work> getWorksByImplementerId(int id);

        void Add(T model);

        void Edit(T model);

        void Delete(int id);
    }
}
