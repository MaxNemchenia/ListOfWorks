using System.Data;
using System.Data.SqlClient;

namespace QulixTestWork
{
    class dbConnection
    {
        string connectionString;
        private SqlDataAdapter adapter;
        private SqlConnection connection;

        

        public dbConnection()
        {
            adapter = new SqlDataAdapter();
            //connectionString = @"Data Source=.\TEW_SQLEXPRESS;Initial Catalog=Work;Integrated Security=True";
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\data\Work.mdf'; Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }


        private SqlConnection openConnection()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            return connection;
        }



        public DataTable Select(string sqlExpression)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                command.Connection = openConnection();
                command.CommandText = sqlExpression;
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0]; 
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }

            return dataTable;
        }


        public bool Insert(string sqlExpression, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = openConnection();
                command.CommandText = sqlExpression;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                return false;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }

            return true;
        }


        public bool Update(string sqlExpression, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = openConnection();
                command.CommandText = sqlExpression;
                command.Parameters.AddRange(sqlParameters);
                adapter.UpdateCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }

            return true;
        }


        public bool Delete(string sqlExpression)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = openConnection();
                command.CommandText = sqlExpression;
                adapter.DeleteCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }

            return true;
        }
    }
}