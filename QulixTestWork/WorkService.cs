using System.Collections.Generic;

namespace QulixTestWork
{
    class WorkService : IService<Work>
    {
        IRepository<Work> repository;


        public WorkService()
        {
            repository = new WorkRepository();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Add(Work work)
        {
            repository.Insert(work);
        }

        public List<Work> getAll()
        {
            List<Work> works = repository.Select();
            return works;
        }

        public List<Work> getWorksByImplementerId(int id)
        {
            List<Work> works = repository.SelectWorksByImplementerId(id);
            return works;
        }

        public Work getById(int id)
        {
            Work work = repository.SelectById(id);
            return work;
        }

        public void Edit(Work work)
        {
            repository.Update(work);
        }
    }
}
