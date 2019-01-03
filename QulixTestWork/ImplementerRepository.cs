using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace QulixTestWork
{
    class ImplementerRepository : IRepository<Implementer>
    {
        dbConnection connection;



        public ImplementerRepository()
        {
            connection = new dbConnection();
        }


        public void Delete(int id)
        {
            string sqlExpression = string.Format("DELETE  from Implementers where id = {0}", id);
            connection.Delete(sqlExpression);
        }


        public void Insert(Implementer implementer)
        {
            string query = "INSERT Into Implementers (FirstName, LastName,  Patronymic) VALUES (@firstName, @lastName, @patronymic)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@firstName", implementer.FirstName);
            sqlParameters[1] = new SqlParameter("@lastName", implementer.LastName);
            sqlParameters[2] = new SqlParameter("@patronymic", implementer.Patronymic);
            connection.Update(query, sqlParameters);
        }


        public List<Implementer> Select()
        {
            ImplementerParser implementersParser = new ImplementerParser();
            DataTable dataTable = new DataTable();
            string sqlExpression = "Select *  from Implementers";
            dataTable = connection.Select(sqlExpression);
            List<Implementer> implementers = implementersParser.Parse(dataTable);
            return implementers;
        }


        public Implementer SelectById(int id)
        {
            ImplementerParser implementersParser = new ImplementerParser();
            DataTable dataTable = new DataTable();
            string sqlExpression = string.Format("Select *  from Implementers where Id={0}", id);
            dataTable = connection.Select(sqlExpression);
            List<Implementer> implementers = implementersParser.Parse(dataTable);
            Implementer implementer = implementers.FirstOrDefault();
            return implementer;
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


        public void Update(Implementer implementer)
        {
            string query = "UPDATE Implementers SET FirstName=@firstName, LastName=@lastName, Patronymic=@patronymic WHERE Id=@id";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@firstName", implementer.FirstName);
            sqlParameters[1] = new SqlParameter("@lastName", implementer.LastName);
            sqlParameters[2] = new SqlParameter("@patronymic", implementer.Patronymic);
            sqlParameters[3] = new SqlParameter("@id", implementer.Id);
            connection.Update(query, sqlParameters);
        }
    }
}
