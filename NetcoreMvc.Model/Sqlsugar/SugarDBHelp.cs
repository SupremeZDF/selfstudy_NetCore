using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;


namespace NetcoreMvc.Model.Sqlsugar
{
    public class SugarDBHelp
    {
        public SqlSugarClient SqlSugarClient;

        public void GetSqlClient() 
        {
            SqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "data source=127.0.0.1:1521/orcl;user id=scott;password=tiger",
                DbType=DbType.Oracle,
                IsAutoCloseConnection=true,
                InitKeyType=InitKeyType.Attribute
            }); 
        }

        public void GetStudent() 
        {
            SqlSugarClient.Aop.OnLogExecuting=(sql,pargs) => {
                Console.WriteLine(sql + "\r\n" +
                SqlSugarClient.Utilities.SerializeObject(pargs.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

            var id= SqlSugarClient.Insertable(new StudentModel() { FID=3, FNAME="1", FNUMBER="1", FPHONE="1", FSEX="1"  }).ExecuteCommand();

            var list = SqlSugarClient.Queryable<StudentModel>().ToList();

        }
    }
}
