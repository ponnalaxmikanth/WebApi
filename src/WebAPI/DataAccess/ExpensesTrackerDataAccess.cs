using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;

namespace DataAccess
{
    public class ExpensesTrackerDataAccess
    {
        public DataTable GetAccountTypes()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetAccountTypes", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetAccountDetails()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetAccountDetails", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetExpenseGroups()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetExpenseGroups", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetExpenseSubGroups()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetExpenseSubGroups", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetStores()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetStore", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetItem(string item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "item", Value = item });

            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetItem", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetStores(string store)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "store", Value = store });

            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetStore", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }


        public DataTable AddExpenseTransaction(ExpenseTransaction transaction)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "transactionDate", Value = transaction.Date });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "groupId", Value = transaction.GroupId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "subgroupid", Value = transaction.SubGroupId }); 
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "item", Value = transaction.Item });
            parameters.Add(new SqlParameter() { DbType = DbType.Decimal, ParameterName = "amount", Value = transaction.Amount });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "accountid", Value = transaction.AccountId });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "transactedBy", Value = transaction.TransactedBy });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "store", Value = transaction.Store });

            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "AddHomeTransactions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetExpenses(GetExpenses request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "fromDate", Value = request.FromDate });
            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "toDate", Value = request.ToDate });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "accountId", Value = request.AccountId });

            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetHomeTransactions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetBudget(GetExpenses request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "fromDate", Value = request.FromDate });
            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "toDate", Value = request.ToDate });

            DataSet ds = SQLHelper.ExecuteProcedure("HomeTransactions", "GetBudgetTransactions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

    }
}
