using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    internal class DBHeadDepartmentTable : IEmployeeTablesWorking
    {
        IDBConnection dBConnection;
        DBPeopleWork dBPeople;
        public DBHeadDepartmentTable(IDBConnection dB)
        {
            dBConnection = dB;
            dBPeople = new DBPeopleWork(dB);
        }

        public DataSet GetTable()
        {
            DataSet ds;
            string sql = "SELECT s.[ID],s.[DateOfBirth],s.[FIO],s.[Gender],d.[Name_Division]" +
                "FROM People s inner JOIN Head_Departnent p ON s.ID =p.ID_People " +
                "inner join Divisions d on p.ID_Division = d.ID_Division";

            dBConnection.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dBConnection.GetConnection());
            ds = new DataSet();
            adapter.Fill(ds);

            dBConnection.CloseConnection();

            return ds;
        }

        private bool CheckDivision(string division)
        {
            string sql = $"SELECT COUNT(*) FROM Divisions WHERE Name_Division = '{division}'";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            object ID_Division = reader.GetValue(0);
            if (((int)ID_Division)>=1)
            {
                reader.Close();
                dBConnection.CloseConnection();
                sqlCommand.Dispose();
                return true;
            }
            reader.Close();
            dBConnection.CloseConnection();
            sqlCommand.Dispose();
            return false;
        }

        public bool UpdateLine(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (CheckDivision(info))
            {
                if (dBPeople.UpdateLine(PeopleId, dateOfBirth, FIO, gen, info))
                {
                    string sql = $"SELECT ID_Division FROM Divisions WHERE Name_Division = '{info}'";
                    dBConnection.OpenConnection();
                    SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    object ID_Division = reader.GetValue(0);
                    reader.Close();

                    sql = $"UPDATE Head_Departnent Set ID_Division = '{(int)ID_Division}' WHERE ID_People = {PeopleId}";

                    sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        dBConnection.CloseConnection();
                        sqlCommand.Dispose();
                        return true;
                    }
                }
            }
            else
                throw new Exception("Подразделение найти не удалось!");

            return false;
        }

        public bool DeleteLine(int PeopleId)
        {
            string sql = $"DELETE [Head_Departnent] WHERE ID_People = {PeopleId}";

            dBConnection.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            if (sqlCommand.ExecuteNonQuery() == 1 && dBPeople.DeleteLine(PeopleId))
            {
                dBConnection.CloseConnection();
                return true;
            }

            dBConnection.CloseConnection();
            return false;
        }

        public bool InsertLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            string sql;
            SqlCommand sqlCommand;
            if (dBPeople.InsertLine(dateOfBirth, FIO, gen, info))
            {
                if (!CheckDivision(info))
                {
                    sql = $"INSERT Divisions VALUES ('{info}')";
                    dBConnection.OpenConnection();
                    sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                    sqlCommand.ExecuteNonQuery();        
                    dBConnection.CloseConnection();
                }

                sql = $"SELECT ID_Division FROM Divisions WHERE Name_Division = '{info}'";
                dBConnection.OpenConnection();
                sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                object ID_Division = reader.GetValue(0);
                reader.Close();

                sql = $"SELECT ID FROM People WHERE FIO = '{FIO}' and DateOfBirth = '{dateOfBirth.ToString("yyyy-MM-dd")}'";
                dBConnection.OpenConnection();
                sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());
                 reader = sqlCommand.ExecuteReader();
                reader.Read();
                object ID = reader.GetValue(0);
                reader.Close();

                sql = $"INSERT Head_Departnent VALUES ({int.Parse(ID.ToString())},{int.Parse(ID_Division.ToString())})";

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
    }
}
