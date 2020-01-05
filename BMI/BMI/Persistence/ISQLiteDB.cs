using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BMI.Persistence
{
    public interface ISQLiteDB
    {
        SQLiteConnection GetSQLiteConnection();
        bool CheckSQLiteDBExist();
    }
}
