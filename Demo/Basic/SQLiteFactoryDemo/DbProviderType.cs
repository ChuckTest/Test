using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFactoryDemo
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DbProviderType : byte
    {
        SqlServer, 
        MySql, 
        SQLite, 
        Oracle, 
        ODBC, //5
        OleDb, 
        Firebird,
        PostgreSql, 
        DB2, 
        Informix,//10
        SqlServerCe  
    }
}
