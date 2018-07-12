using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;


namespace DataAccess
{
    public class SQLHelper
    {
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static DataSet ExecuteProcedure(string key, string procName, CommandType cmdType, List<SqlParameter> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                string connstr = GetConnectionString(key);
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());
                        cmd.CommandType = cmdType;

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(ds);
                    }
                }
            }
            catch (Exception exc)
            {

            }
            finally
            {

            }
            return ds;
        }

    }
}
