using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QulixTestWork
{
    class WorkRepository : IRepository<Work>
    {
        dbConnection connection;



        public WorkRepository()
        {
            connection = new dbConnection();
        }



        public void Delete(int id)
        {
            string sqlExpression = string.Format("DELETE  from Works where id = {0}", id);
            connection.Delete(sqlExpression);
        }


        public void Insert(Work work)
        {
            string query = "INSERT Into Works (WorkName, StartDate,  EndDate, Status, ImplementerId) VALUES (@workName, @startDate, @endDate, @status, @implementerId)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@workName", work.WorkName);
            sqlParameters[1] = new SqlParameter("@startDate", work.StartDate);
            sqlParameters[2] = new SqlParameter("@endDate", work.EndDate);
            sqlParameters[3] = new SqlParameter("@status", work.Status);
            sqlParameters[4] = new SqlParameter("@implementerId", work.ImplementerId);
            connection.Update(query, sqlParameters);
        }


        public List<Work> Select()
        {
            WorkParser workParser = new WorkParser();
            DataTable dataTable = new DataTable();
            string sqlExpression = "Select *  from Works";
            dataTable = connection.Select(sqlExpression);
            List<Work> works = workParser.Parse(dataTable);
            return works;
        }

        public Work SelectById(int id)
        {
            WorkParser workParser = new WorkParser();
            DataTable dataTable = new DataTable();
            string sqlExpression =string.Format("Select *  from Works where Id={0}", id);
            dataTable = connection.Select(sqlExpression);
            List<Work> works = workParser.Parse(dataTable);
            Work work = works.FirstOrDefault();
            return work;
        }

        public List<Work> SelectWorksByImplementerId(int id)
        {
            WorkParser workParser = new WorkParser();
            DataTable dataTable = new DataTable();
            string sqlExpression = string.Format("Select *  from Works where ImplementerId={0}", id);
            dataTable = connection.Select(sqlExpression);
            List<Work> works = workParser.Parse(dataTable);
            return works;
        }


        public void Update(Work work)
        {
            string query = "UPDATE Works SET WorkName=@workName, StartDate=@startDate, EndDate=@endDate, Status=@status, ImplementerId=@implementerId WHERE Id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@workName", work.WorkName);
            sqlParameters[1] = new SqlParameter("@startDate", work.StartDate);
            sqlParameters[2] = new SqlParameter("@endDate", work.EndDate);
            sqlParameters[3] = new SqlParameter("@status", work.Status);
            sqlParameters[4] = new SqlParameter("@implementerId", work.ImplementerId);
            sqlParameters[5] = new SqlParameter("@id", work.Id);
            connection.Update(query, sqlParameters);
        }
    }
}
