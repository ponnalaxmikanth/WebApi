using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class MutualFundsRepository
    {
        public List<Funds> GetFunds()
        {
            return MapFunds(new MutualFundsDataAccess().GetFunds());
        }

        private List<Funds> MapFunds(DataTable datatable)
        {
            List<Funds> result = new List<Funds>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new Funds()
                          {
                              FundHouseId = int.Parse(dr["FundHouseId"].ToString()),
                              SchemaCode = int.Parse(dr["SchemaCode"].ToString()),
                              Name = dr["SchemaName"].ToString(),
                              DividendReInvestISIN = dr["ISIN_DIV_Reinvestment"].ToString(),
                              GrowthISIN = dr["ISINGrowth"].ToString()
                          }).ToList();
            }
            return result;
        }


        public List<MF_FundHouses> GetFundHouses()
        {
            return MapFundHouses(new MutualFundsDataAccess().GetFundHouses());
        }

        private List<MF_FundHouses> MapFundHouses(DataTable datatable)
        {
            List<MF_FundHouses> result = new List<MF_FundHouses>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MF_FundHouses()
                          {
                              FundHouseId = int.Parse(dr["FundHouseId"].ToString()),
                              FundHouseName = dr["FundHouseName"].ToString()
                          }).ToList();
            }
            return result;
        }


        public List<MF_FundTypes> GetFundTypes()
        {
            return MapFundTypes(new MutualFundsDataAccess().GetFundTypes());
        }

        private List<MF_FundTypes> MapFundTypes(DataTable datatable)
        {
            List<MF_FundTypes> result = new List<MF_FundTypes>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MF_FundTypes()
                          {
                              FundTypeId = int.Parse(dr["FundTypeId"].ToString()),
                              FundType = dr["FundType"].ToString()
                          }).ToList();
            }
            return result;
        }


        public List<MF_FundCategory> GetFundCategory()
        {
            return MapFundCategory(new MutualFundsDataAccess().GetFundCategory());
        }

        private List<MF_FundCategory> MapFundCategory(DataTable datatable)
        {
            List<MF_FundCategory> result = new List<MF_FundCategory>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MF_FundCategory()
                          {
                              FundClassId = int.Parse(dr["FundClassId"].ToString()),
                              FundClass = dr["FundClass"].ToString(),
                              IsSectorCategory = dr["IsSectorCategory"].ToString() == "1" ? true : false
                          }).ToList();
            }
            return result;
        }

        public List<MF_FundOptions> GetFundOptions()
        {
            return MapFundOptions(new MutualFundsDataAccess().GetFundOptions());
        }

        private List<MF_FundOptions> MapFundOptions(DataTable datatable)
        {
            List<MF_FundOptions> result = new List<MF_FundOptions>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MF_FundOptions()
                          {
                              OptionId = int.Parse(dr["OptionId"].ToString()),
                              FundOption = dr["FundOption"].ToString(),
                          }).ToList();
            }
            return result;
        }


        public List<MF_Folios> GetFolios()
        {
            return MapFolios(new MutualFundsDataAccess().GetFolios());
        }

        private List<MF_Folios> MapFolios(DataTable datatable)
        {
            List<MF_Folios> result = new List<MF_Folios>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MF_Folios()
                          {
                              FolioId = int.Parse(dr["FolioId"].ToString()),
                              FolioNumber = dr["FolioNumber"].ToString(),
                              Description = dr["Description"].ToString(),
                              FundHouseId = int.Parse(dr["FundHouseId"].ToString()),
                              PortfolioId = int.Parse(dr["portfolioId"].ToString()),
                              isDefaultFolio = dr["isDefaultFolio"].ToString() == "Y" ? true : false
                          }).ToList();
            }
            return result;
        }


        public List<PortFolioDetails> GetPortfolios()
        {
            return MapPortFolioDetails(datatable: new MutualFundsDataAccess().GetPortfolios());
        }

        private List<PortFolioDetails> MapPortFolioDetails(DataTable datatable)
        {
            List<PortFolioDetails> result = new List<PortFolioDetails>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new PortFolioDetails()
                          {
                              PortfolioId = int.Parse(dr["PortfolioId"].ToString()),
                              PortfolioName = dr["Portfolio"].ToString()
                          }).ToList();
            }
            return result;
        }


        public List<MFFund> GetMyFunds(GetMyFundsRequest request)
        {
            return MapMyFunds(datatable: new MutualFundsDataAccess().GetMyFunds(request));
        }

        private List<MFFund> MapMyFunds(DataTable datatable)
        {
            List<MFFund> result = new List<MFFund>();

            if (datatable != null && datatable.Rows.Count > 0)
            {
                result = (from dr in datatable.AsEnumerable()
                          select new MFFund()
                          {
                              FundCategory = new MF_FundCategory()
                              {
                                  FundClassId = int.Parse(dr["FundClassId"].ToString()),
                                  FundClass = dr["FundClass"].ToString()
                              },
                              FundHouse = new MF_FundHouses()
                              {
                                  FundHouseId = int.Parse(dr["FundHouseId"].ToString()),
                                  FundHouseName = dr["FundHouseName"].ToString()
                              },
                              FundOptions = new MF_FundOptions()
                              {
                                  OptionId = int.Parse(dr["FundOptionId"].ToString()),
                                  FundOption = dr["FundOption"].ToString()
                              },
                              FundType = new MF_FundTypes()
                              {
                                  FundTypeId = int.Parse(dr["FundTypeId"].ToString()),
                                  FundType = dr["FundType"].ToString()
                              },
                              PortfolioId = int.Parse(dr["PortfolioId"].ToString()),
                              FundId = int.Parse(dr["FundId"].ToString()),
                              SchemaCode = int.Parse(dr["SchemaCode"].ToString()),
                              FundName = dr["FundName"].ToString(),

                              GrowthSchemaCode = int.Parse(dr["GrowthSchemaCode"].ToString()),
                              GrowthFundName = dr["SchemaName"].ToString()

                          }).ToList();
            }
            return result;
        }

        public void AddTransaction(AddMFTransactionRequest mfTransactionRequest)
        {
            new MutualFundsDataAccess().AddTransaction(mfTransactionRequest);
        }

        public decimal GetFundNav(GetFundNavRequest getFundNavRequest)
        {
            DataTable dtResult = new MutualFundsDataAccess().GetFundNav(getFundNavRequest);

            if (dtResult != null && dtResult.Rows.Count > 0)
                return decimal.Parse(dtResult.Rows[0]["NAV"].ToString());
            else
                return -9999999;
        }

        public FundValueResponse GetFundValue(GetFundValueRequst getFundValueRequest)
        {
            DataTable dtResult = new MutualFundsDataAccess().GetFundValue(getFundValueRequest);

            return MapFundValue(dtResult);
        }

        private FundValueResponse MapFundValue(DataTable dtResult)
        {
            FundValueResponse response = null;
            if (dtResult != null)
            {
                response = (from dr in dtResult.AsEnumerable()
                            select new FundValueResponse()
                            {
                                SchemaCode = int.Parse(dr["SchemaCode"].ToString()),
                                Amount = decimal.Parse(dr["Amount"].ToString()),
                                AvgNav = decimal.Parse(dr["avgNav"].ToString()),
                                Date = DateTime.Parse(dr["Date"].ToString()),
                                Dividend = decimal.Parse(dr["Dividend"].ToString()),
                                LatestNav = decimal.Parse(dr["latestNav"].ToString()),
                                LatestValue = decimal.Parse(dr["LatestValue"].ToString()),
                                Units = decimal.Parse(dr["Units"].ToString()),
                            }).FirstOrDefault();
            }
            return response;
        }

        public List<MFTransactions> GetMFFundInvestments(GetMFFundInvestmentsRequest _getMFFundInvestmentsRequest)
        {
            DataTable dtResult = new MutualFundsDataAccess().GetMyMFFundInvestments(_getMFFundInvestmentsRequest);

            return MapMFFundInvestments(dtResult);
        }

        private List<MFTransactions> MapMFFundInvestments(DataTable dtResult)
        {
            List<MFTransactions> result = null;
            if(dtResult != null)
            {
                result = (from dr in dtResult.AsEnumerable()
                          select new MFTransactions()
                          {
                              TransactionId = int.Parse(dr["TransactionId"].ToString()),
                              FolioId = int.Parse(dr["FolioId"].ToString()),
                              FundDetails = new FundDetails()
                              {
                                  FundId = int.Parse(dr["FundId"].ToString()),
                              },
                              PurchaseDate = DateTime.Parse(dr["PurchaseDate"].ToString()),
                              Amount = decimal.Parse(dr["Amount"].ToString()),
                              Units = decimal.Parse(dr["Units"].ToString()),
                              DividendPerNAV = decimal.Parse(dr["DividendPerNAV"].ToString()),
                              Dividend = decimal.Parse(dr["Dividend"].ToString())
                          }).ToList();
            }
            return result;
        }
    }
}
