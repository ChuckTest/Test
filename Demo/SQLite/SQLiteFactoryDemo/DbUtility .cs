using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;
namespace SQLiteFactoryDemo
{
    /// <summary>  
    /// 通用数据库访问类，封装了对数据库的常见操作  http://zhoufoxcn.blog.51cto.com/792419/622376
    /// </summary>  
    public sealed class DbUtility
    {
        public DbUtility(string connectString,DbProviderType providerType)
        {
            ConnectionString = connectString;
            providerFactory = ProviderFactory.GetDbProviderFactory(providerType); 
            if (providerFactory == null)
            {
                throw new ArgumentException("Can't load DbProviderFactory for given value of providerType");
            }  
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get;
            private set;
        }

        private DbProviderFactory providerFactory;

        /// <summary>
        /// 执行一个查询语句，返回一个关联的DataReader实例 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters)
        { 
            return ExecuteReader(sql, parameters, CommandType.Text); 
        }

        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters, CommandType commandType) 
        { 
            DbCommand command = CreateDbCommand(sql, parameters, commandType); 
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection); 
        }

        /// <summary>
        /// 创建一个DbCommand对象  
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        private DbCommand CreateDbCommand(string sql, IList<DbParameter> parameters, CommandType commandType) 
        {
            DbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = ConnectionString; 

            DbCommand command = providerFactory.CreateCommand(); 
            command.CommandText = sql;
            command.CommandType = commandType; 
            command.Connection = connection; 

            if (!(parameters == null || parameters.Count == 0)) 
            { 
                foreach (DbParameter parameter in parameters) 
                { 
                    command.Parameters.Add(parameter);
                } 
            } 
            return command;
        }

        /// <summary>
        ///  执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters)
        { 
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }  

        /// <summary>
        /// 执行一个查询语句，返回一个包含查询结果的DataTable     
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            try
            {
                using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
                {
                    using (DbDataAdapter adapter = providerFactory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。      
        /// </summary>   
        /// <param name="sql">要执行的增删改的SQL语句</param>   
        /// <param name="parameters">执行增删改语句所需要的参数</param>   
        /// <returns></returns>     
        public int ExecuteNonQuery(string sql,IList<DbParameter> parameters)  
        {   
            return ExecuteNonQuery(sql, parameters, CommandType.Text);  
        }  
        
        /// <summary>     
        /// 对数据库执行增删改操作，返回受影响的行数。      
        /// </summary>      
        /// <param name="sql">要执行的增删改的SQL语句</param>     
        /// <param name="parameters">执行增删改语句所需要的参数</param>  
        /// <param name="commandType">执行的SQL语句的类型</param>   
        /// <returns></returns>   
        public int ExecuteNonQuery(string sql,IList<DbParameter> parameters, CommandType commandType)  
        {   
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))  
            {   
                command.Connection.Open();     
                int affectedRows=command.ExecuteNonQuery();  
                command.Connection.Close();  
                return affectedRows;
            } 
        }  
    }
}
