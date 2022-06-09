using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    public interface IModel
    {
        DataSet getWoerkerTable();
        DataSet getControllersTable();
        DataSet getDirectorsTable();
        DataSet getHeadDepartmentTable();

        void UpdateWorker(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info);
        void UpdateDirectors(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info);
        void UpdateControllers(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info);
        void UpdateHeadDepartment(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info);

        void DeleteWorkerLine(int PeopleId);
        void DeleteDirectorsLine(int PeopleId);
        void DeleteControllerLine(int PeopleId);
        void DeleteHeadepartmentLine(int PeopleId);

        void AddWorkerLine(DateTime dateOfBirth, string FIO, string gen, string info);
        void AddDirectorsLine(DateTime dateOfBirth, string FIO, string gen, string info);
        void AddControllersLine(DateTime dateOfBirth, string FIO, string gen, string info);
        void AddHeadDepartmentLine(DateTime dateOfBirth, string FIO, string gen, string info);
        void UpdateTables(DataSet ds);
        object[] getDivisions();
        DataSet getDivisionTable(string div);
    }
    internal class Model:IModel
    {
        IDBConnection dBConnection;
        IEmployeeTablesWorking workerTable;
        IEmployeeTablesWorking controllersTable;
        IEmployeeTablesWorking directorsTable;
        IEmployeeTablesWorking headDepartmentTable;

        public Model(IDBConnection dB)
        {
            dBConnection = dB;
            workerTable = new DBWorkerTable(dB);
            controllersTable = new DBControllersTable(dB);
            directorsTable = new DBDirectorsTable(dB);
            headDepartmentTable = new DBHeadDepartmentTable(dB);
        }

        public DataSet getControllersTable()
        {
            return controllersTable.GetTable();
        }

        public DataSet getDirectorsTable()
        {
            return directorsTable.GetTable();
        }

        public DataSet getHeadDepartmentTable()
        {
            return headDepartmentTable.GetTable();
        }

        public DataSet getWoerkerTable()
        {
            return workerTable.GetTable();
        }
        public void UpdateWorker(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!workerTable.UpdateLine(PeopleId, dateOfBirth, FIO, gen, info))
                throw new Exception("Обновить таблицу работников не удалось!");
        }
        public void UpdateTables(DataSet ds)
        {
            
        }

        public void UpdateDirectors(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!directorsTable.UpdateLine(PeopleId, dateOfBirth, FIO, gen, info))
                throw new Exception("Обновить таблицу директоров не удалось!");
        }

        public void UpdateControllers(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!controllersTable.UpdateLine(PeopleId,dateOfBirth, FIO, gen,info))
                throw new Exception("Обновить таблицу контролеров не удалось!");
        }

        public void UpdateHeadDepartment(int PeopleId, DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!headDepartmentTable.UpdateLine(PeopleId,dateOfBirth,FIO,gen,info))
                throw new Exception("Обновить таблицу руководителей подразделения не удалось!");
        }

        public void DeleteWorkerLine(int PeopleId)
        {
            if (!workerTable.DeleteLine(PeopleId))
                throw new Exception("не удалось удалить запись из таблицы работников!");
        }

        public void DeleteDirectorsLine(int PeopleId)
        {
            if (!directorsTable.DeleteLine(PeopleId))
                throw new Exception("не удалось удалить запись из таблицы директоров!");
        }

        public void DeleteControllerLine(int PeopleId)
        {
            if (!controllersTable.DeleteLine(PeopleId))
                throw new Exception("не удалось удалить запись из таблицы контролеров!");
        }

        public void DeleteHeadepartmentLine(int PeopleId)
        {
            if (!headDepartmentTable.DeleteLine(PeopleId))
                throw new Exception("не удалось удалить запись из таблицы руководителей подразделения!");
        }

        public void AddWorkerLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!workerTable.InsertLine(dateOfBirth, FIO, gen,info))
                throw new Exception("не удалось добавить запись в таблицу работников!");
        }

        public void AddDirectorsLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!directorsTable.InsertLine(dateOfBirth,FIO, gen,info))
                throw new Exception("не удалось добавить запись в таблицу директоров!");
        }

        public void AddControllersLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!controllersTable.InsertLine(dateOfBirth,FIO,gen,info))
                throw new Exception("не удалось добавить запись в таблицу контролеров!");

        }

        public void AddHeadDepartmentLine(DateTime dateOfBirth, string FIO, string gen, string info)
        {
            if (!headDepartmentTable.InsertLine(dateOfBirth, FIO, gen, info))
                throw new Exception("не удалось добавить запись в таблицу руководителей!");
        }

        public object[] getDivisions()
        {
            DBDivisionTable dBDivision = new DBDivisionTable(dBConnection);
            return dBDivision.GetDivisions();
        }

        public DataSet getDivisionTable(string div)
        {
            DBDivisionTable dBDivision = new DBDivisionTable(dBConnection);
            return dBDivision.GetHeadDepInDivision(div);
        }
    }
}
