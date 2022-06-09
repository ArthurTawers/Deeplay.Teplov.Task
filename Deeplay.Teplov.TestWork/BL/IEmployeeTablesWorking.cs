using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deeplay.Teplov.TestWork.BL
{
    internal interface IEmployeeTablesWorking
    {
        DataSet GetTable();
        bool InsertLine(DateTime dateOfBirth, string FIO, string gen, string info);

        bool UpdateLine(int PeopleId,DateTime dateOfBirth, string FIO, string gen,string info);

        bool DeleteLine(int PeopleId);
    }
}
