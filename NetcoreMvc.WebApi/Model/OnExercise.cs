using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Google.Protobuf.WellKnownTypes;
using System.Threading;
using System.IO;
using System.Text;

namespace NetcoreMvc.WebApi.Model
{
    public class OnExercise
    {

        public int? Input = 1;

        public int? InputOutput = 2;

        public int? Output = 3;

        public int? ReturnValue = 4;



        public int? Input2;

        public int? InputOutput2;

        public int? Output2;

        public int? ReturnValue2;

        public void OneRun() 
        {
            string a = "123";
            SqlParameter sqlParameter = new SqlParameter();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "";
            sqlCommand.Parameters.Add(new SqlParameter());
        }

        /// <summary>
        /// 
        /// </summary>
        public void StoredProcedure() 
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Dapper;Integrated Security=True");

                SqlCommand cmd = new SqlCommand();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "proc_test_SQLParametersValueS";

                cmd.Parameters.Add("@Input", SqlDbType.Int);
                var i = cmd.Parameters["@Input"].Direction;
                var ii = 1;
                SqlParameter parameter = new SqlParameter("@sss", System.Data.SqlDbType.Int);
                var ddd = parameter.Direction;

                cmd.Parameters["@Input"].Direction = ParameterDirection.InputOutput;
                if (Input == null)
                {
                    cmd.Parameters["@Input"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@Input"].Value = Input;
                }
                cmd.Parameters.Add("@InputOutput", System.Data.SqlDbType.Int);
                cmd.Parameters["@InputOutput"].Direction = ParameterDirection.InputOutput;
                if (InputOutput == null)
                {
                    cmd.Parameters["@InputOutput"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@InputOutput"].Value = InputOutput;
                }
                cmd.Parameters.Add("@Output", System.Data.SqlDbType.Int);
                cmd.Parameters["@Output"].Direction = ParameterDirection.InputOutput;
                if (Output == null)
                {
                    cmd.Parameters["@Output"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@Output"].Value = Output;
                }
                cmd.Parameters.Add("@s", System.Data.SqlDbType.Int);
                cmd.Parameters["@s"].Direction = ParameterDirection.ReturnValue;
                if (ReturnValue == null)
                {
                    cmd.Parameters["@s"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@s"].Value = ReturnValue;
                }
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                var value = cmd.Parameters["@s"].Value;
                var c = cmd.Parameters["@Input"].Value;
                var d = cmd.Parameters["@InputOutput"].Value;
                var e = cmd.Parameters["@Output"].Value;

                FileStream fileStream = new FileStream("SSS",FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(fileStream,Encoding.GetEncoding(""));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
