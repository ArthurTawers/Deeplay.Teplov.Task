using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    public interface IDBConnection
    {
        void OpenConnection();
        void CloseConnection();
        SqlConnection GetConnection();
    }
    
    internal class DataBaseСonnaction:IDBConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ARTHURPC;Initial Catalog=PersonnelBase;Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }


        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
