using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    internal class DBPeopleWork : IEmployeeTablesWorking
    {
        IDBConnection dBConnection;
        public DBPeopleWork(IDBConnection dB)
        {
            dBConnection = dB;
        }

        public bool DeleteLine(int PeopleId)
        {
            string sql = $"DELETE [People] WHERE ID = {PeopleId}";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                dBConnection.CloseConnection();
                return true;
            }

            dBConnection.CloseConnection();
            return false;
        }

        public DataSet GetTable()
        {
            DataSet ds;
            string sql = "SELECT [ID],[DateOfBirth],[FIO],[Gender] FROM People";

            dBConnection.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dBConnection.GetConnection());
            ds = new DataSet();
            adapter.Fill(ds);
            dBConnection.CloseConnection();

            return ds;
        }

        public bool InsertLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            string sql = $"INSERT People VALUES ('{dateOfBirth.ToString("yyyy-MM-dd")}', '{FIO}', '{gen}')";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                dBConnection.CloseConnection();
                return true;
            }

            dBConnection.CloseConnection();
            return false;
        }

        public bool UpdateLine(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            string sql = $"UPDATE People Set FIO = '{FIO}',DateOfBirth='{dateOfBirth.ToString("yyyy-MM-dd")}',Gender='{gen}' WHERE People.ID = {PeopleId}";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                dBConnection.CloseConnection();
                return true;
            }

            dBConnection.CloseConnection();
            return false;
        }
    }
}
