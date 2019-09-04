﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
     public class StocksDataAccess
    {
        public DataTable GetToStocks(DateTime fromdate, DateTime todate, int Detail)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "fromdate", Value = fromdate });
            //parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "todate", Value = todate });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "details", Value = Detail });

            DataSet ds = SQLHelper.ExecuteProcedure("Investments", "GetStocks", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable SoldStocks()
        {
            return null;
        }
        public DataTable PurchaseStocks()
        {
            return null;
        }
        public DataTable DividendStocks()
        {
            return null;
        }
    }
}
