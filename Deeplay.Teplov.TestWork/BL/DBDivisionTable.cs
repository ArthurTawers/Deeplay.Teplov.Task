using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    internal class DBDivisionTable
    {
        IDBConnection dBConnection;

        public DBDivisionTable(IDBConnection dB)
        {
            dBConnection = dB;
        }

        public DataSet GetHeadDepInDivision(string div)
        {
            DataSet ds;
            string sql = $"SELECT s.[ID],s.[DateOfBirth],s.[FIO],s.[Gender],d.[Name_Division] "+
                "FROM People s inner JOIN Head_Departnent p ON s.ID =p.ID_People "+
                $"inner join Divisions d on d.Name_Division = '{div}' and p.ID_Division = d.ID_Division";
            
            dBConnection.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dBConnection.GetConnection());
            ds = new DataSet();
            adapter.Fill(ds);
            dBConnection.CloseConnection();

            return ds;
        }

        public string[] GetDivisions()
        {
            DataSet ds;
            string sql = "SELECT [Name_Division] FROM [PersonnelBase].[dbo].[Divisions]";

            SqlCommand sqlCommand = new SqlCommand(sql, dBConnection.GetConnection());

            dBConnection.OpenConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string> fields = new List<string>();
           
            while(reader.Read())
            {
                fields.Add(reader.GetString(0));
            }

            reader.Close();
            dBConnection.CloseConnection();

            return fields.ToArray();
        }

    }
}
