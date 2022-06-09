using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    internal class DBControllersTable : IEmployeeTablesWorking
    {
        IDBConnection dBConnection;
        DBPeopleWork dBPeople;
        public DBControllersTable(IDBConnection dB)
        {
            dBConnection = dB;
            dBPeople = new DBPeopleWork(dB);
        }

        public bool DeleteLine(int PeopleId)
        {
            string sql = $"DELETE [Controllers] WHERE ID_People = {PeopleId}";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            if (sqlCommand.ExecuteNonQuery() == 1 && dBPeople.DeleteLine(PeopleId))
            {
                sqlCommand.Dispose();
                dBConnection.CloseConnection();
                return true;
            }

            sqlCommand.Dispose();
            dBConnection.CloseConnection();
            return false;
        }

        public DataSet GetTable()
        {
            DataSet ds;
            string sql = "SELECT [ID],[DateOfBirth],[FIO],[Gender],[Machine_Info] FROM People JOIN Controllers ON People.ID = Controllers.ID_People";

            dBConnection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, dBConnection.GetConnection());
            ds = new DataSet();
            adapter.Fill(ds);
            dBConnection.CloseConnection();

            return ds;
        }

        public bool InsertLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (dBPeople.InsertLine(dateOfBirth, FIO, gen, info))
            {
                string sql = $"SELECT ID FROM People WHERE FIO = '{FIO}' and DateOfBirth = '{dateOfBirth.ToString("yyyy-MM-dd")}'";
                dBConnection.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                object ID = reader.GetValue(0);
                reader.Close();

                sql = $"INSERT Controllers VALUES ({int.Parse(ID.ToString())},'{info}')";

                sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    dBConnection.CloseConnection();
                    return true;
                }
            }
            dBConnection.CloseConnection();
            return false;
        }

        public bool UpdateLine(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (dBPeople.UpdateLine(PeopleId, dateOfBirth, FIO, gen, info))
            {
                dBConnection.OpenConnection();
                string sql = $"UPDATE Controllers Set Machine_Info = '{info}' WHERE ID_People = {PeopleId}";

                SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    dBConnection.CloseConnection();
                    return true;
                }
            }

            return false;
        }
    }
}
