using BusinessEntity;
using BusinessEntity.MutualFunds;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MutualFundsDataAccess
    {
        public DataTable GetInvestments(DashboardIndividual request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "PortfolioId", Value = request.PortfolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "Type", Value = request.Type });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetIndividualTransactions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFundHouses()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_FundHouses", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null; 
        }

        public DataTable GetFundTypes()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_FundTypes", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFundCategory()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_FundCategory", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFundOptions()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_FundOptions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }
        
        public DataTable GetFunds()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetMFFunds", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetMyFunds(GetMyFundsRequest request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "transaction", Value = request.Type });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "portfolioId", Value = request.PortfolioId });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetMyFunds", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFolios()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_Folios", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetPortfolios()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_MF_Portfolios", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable AddTransaction(AddMFTransactionRequest request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "PortfolioId", Value = request.PortfolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "houseId", Value = request.FundHouseId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "typeId", Value = request.FundTypeId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "categoryId", Value = request.FundCategoryId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "optionsId", Value = request.FundOptionsId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "schemaCode", Value = request.SchemaCode });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "growthschemaCode", Value = request.GrowthSchemaCode });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "fundName", Value = request.FundName });
            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "PurchaseDate", Value = request.PurchaseDate.Date });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "FolioId", Value = request.FolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.Decimal, ParameterName = "Amount", Value = request.Amount });
            parameters.Add(new SqlParameter() { DbType = DbType.Decimal, ParameterName = "PurchaseNAV", Value = request.PurchaseNAV });
            parameters.Add(new SqlParameter() { DbType = DbType.Decimal, ParameterName = "Units", Value = request.Units });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "SIP", Value = (request.IsSIP == true ? "Y" : "N") });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "AddMFPurchase", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;

        }

        public DataTable GetFundNav(GetFundNavRequest getFundNavRequest)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "schemaCode", Value = getFundNavRequest.SchemaCode });
            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "date", Value = getFundNavRequest.Date.Date });
            

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetFundPrice", CommandType.StoredProcedure, parameters);

            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFundValue(GetFundValueRequst getFundValueRequest)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "portfolio", Value = getFundValueRequest.PortfolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "schemaCode", Value = getFundValueRequest.SchemaCode });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "folioId", Value = getFundValueRequest.FolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "optionId", Value = getFundValueRequest.OptionId });


            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetFundValue", CommandType.StoredProcedure, parameters);

            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetMyMFFundInvestments(GetMFFundInvestmentsRequest request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "portfolioId", Value = request.PortfolioId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "fundid", Value = request.FundId });
            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "folioId", Value = request.FolioId });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetMyMFFundInvestments", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetMFDdailyTracker(GetMFDailyTracker request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "fromDate", Value = request.fromDate });
            parameters.Add(new SqlParameter() { DbType = DbType.Date, ParameterName = "toDate", Value = request.toDate });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetMFDdailyTracker", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetFundTransactions(MutualFundRequest getFundTransactions)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.Int32, ParameterName = "@PortfolioId", Value = getFundTransactions.PortfolioId });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "GetIndividualTransactions", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

        public DataTable GetInvestmentsByMonth(DashboardRequest request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "FromDate", Value = request.FromDate });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "ToDate", Value = request.ToDate });
            parameters.Add(new SqlParameter() { DbType = DbType.String, ParameterName = "portfolioId", Value = request.PortfolioId });

            DataSet ds = SQLHelper.ExecuteProcedure("PersonalFinance", "Get_Investments_Details", CommandType.StoredProcedure, parameters);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }

    }
}
