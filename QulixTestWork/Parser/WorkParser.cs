using System;
using System.Collections.Generic;
using System.Data;

namespace QulixTestWork
{
    class WorkParser : IParser<Work>
    {
        ImplementerService ImplementerService = new ImplementerService();
        public List<Work> Parse(DataTable dataTable)
        {
            List<Work> works = new List<Work>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Work work = new Work();
                work.Id = Int32.Parse(dr["Id"].ToString());
                work.WorkName = dr["WorkName"].ToString();
                work.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                work.EndDate = DateTime.Parse(dr["EndDate"].ToString());
                work.Status = (Status)Int32.Parse(dr["Status"].ToString());
                work.ImplementerId = Int32.Parse(dr["ImplementerId"].ToString());
                work.Implementer = ImplementerService.getById(work.ImplementerId);
                works.Add(work);
            }

            return works;
        }
    }
}
