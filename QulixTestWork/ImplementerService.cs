using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixTestWork
{
    class ImplementerService:IService<Implementer>
    {
        IRepository<Implementer> repository;


        public ImplementerService()
        {
            repository = new ImplementerRepository();
        }


        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Add(Implementer implementer)
        {
            repository.Insert(implementer);
        }

        public List<Implementer> getAll()
        {
            List<Implementer> implementers = repository.Select();
            return implementers;
        }

        public List<Work> getWorksByImplementerId(int id)
        {
            List<Work> works = repository.SelectWorksByImplementerId(id);
            return works;
        }

        public Implementer getById(int id)
        {
            Implementer implementer = repository.SelectById(id);
            return implementer;
        }

        public void Edit(Implementer implementer)
        {
            repository.Update(implementer);
        }
    }
}
