using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixTestWork
{
    class ImplementerParser:IParser<Implementer>
    {
        public List<Implementer> Parse(DataTable dataTable)
        {
            List<Implementer> implementers = new List<Implementer>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Implementer implementer = new Implementer();
                implementer.Id = Int32.Parse(dr["Id"].ToString());
                implementer.FirstName = dr["FirstName"].ToString();
                implementer.LastName = dr["LastName"].ToString();
                implementer.Patronymic = dr["Patronymic"].ToString();
                implementers.Add(implementer);
            }

            return implementers;
        }
    }
}
