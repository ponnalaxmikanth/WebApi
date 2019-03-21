using BusinessEntity;
using BusinessEntity.MutualFunds;
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
        readonly MutualFundsDataAccess _mutualFundsDataAccess = new MutualFundsDataAccess();

        public MutualFundsRepository()
        {
            //this._mutualFundsDataAccess = _mutualFundsDataAccess;
        }

        public List<Funds> GetFunds()
        {
            return MapFunds(_mutualFundsDataAccess.GetFunds());
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
            return MapFundHouses(_mutualFundsDataAccess.GetFundHouses());
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
            return MapFundTypes(_mutualFundsDataAccess.GetFundTypes());
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
            return MapFundCategory(_mutualFundsDataAccess.GetFundCategory());
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
            return MapFundOptions(_mutualFundsDataAccess.GetFundOptions());
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
            return MapFolios(_mutualFundsDataAccess.GetFolios());
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
            return MapPortFolioDetails(datatable: _mutualFundsDataAccess.GetPortfolios());
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
            return MapMyFunds(datatable: _mutualFundsDataAccess.GetMyFunds(request));
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

        public AddMFTransactionResponse AddTransaction(AddMFTransactionRequest mfTransactionRequest)
        {
            int retVal = -1;
            AddMFTransactionResponse response = new AddMFTransactionResponse();
             DataTable dtResult = _mutualFundsDataAccess.AddTransaction(mfTransactionRequest);

            if (dtResult == null || dtResult.Rows.Count <= 0)
            {
                response = new AddMFTransactionResponse()
                {
                    ReturnCode = retVal,
                    ReturnMessage = "Failed to update!!"
                };
            }

            int.TryParse(dtResult.Rows[0][0].ToString(), out retVal);

            if (retVal == 0)
            {
                response = new AddMFTransactionResponse()
                {
                    ReturnCode = retVal,
                    ReturnMessage = "Success"
                };
            }
            else
            {
                response = new AddMFTransactionResponse()
                {
                    ReturnCode = retVal,
                    ReturnMessage = "Failed to update!!"
                };
            }

            return response;
        }

        public decimal GetFundNav(GetFundNavRequest getFundNavRequest)
        {
            DataTable dtResult = _mutualFundsDataAccess.GetFundNav(getFundNavRequest);

            if (dtResult != null && dtResult.Rows.Count > 0)
                return decimal.Parse(dtResult.Rows[0]["NAV"].ToString());
            else
                return -9999999;
        }

        public FundValueResponse GetFundValue(GetFundValueRequst getFundValueRequest)
        {
            DataTable dtResult = _mutualFundsDataAccess.GetFundValue(getFundValueRequest);

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
            DataTable dtResult = _mutualFundsDataAccess.GetMyMFFundInvestments(_getMFFundInvestmentsRequest);

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

        public List<DailyMFTracker> GetMFDdailyTracker(GetMFDailyTracker request)
        {
            try
            {
                return MapFundTransactions(_mutualFundsDataAccess.GetMFDdailyTracker(request));
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        private List<DailyMFTracker> MapFundTransactions(DataTable dataTable)
        {
            try
            {
                if(dataTable!= null && dataTable.Rows.Count > 0)
                {
                    return (from dr in dataTable.AsEnumerable()
                              select new DailyMFTracker()
                              {
                                  Date = DateTime.Parse(dr["date"].ToString()),
                                  Investment = decimal.Parse(dr["investment"].ToString()),
                                  CurrentValue = decimal.Parse(dr["investment"].ToString()),
                                  Profit = decimal.Parse(dr["profit"].ToString()),
                                  PortfolioId = int.Parse(dr["portfolioId"].ToString())
                              }).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }


        public List<MutualFundTransactions> GetFundTransactions(MutualFundRequest getFundTransactions)
        {
            try
            {
                   return MapMutualFundTransactions(_mutualFundsDataAccess.GetFundTransactions(getFundTransactions));
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        private List<MutualFundTransactions> MapMutualFundTransactions(DataTable dataTable)
        {
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (from dr in dataTable.AsEnumerable()
                            group dr by new
                            {
                                PortfolioId = int.Parse(dr["PortfolioId"].ToString()),
                                Portfolio = dr["Portfolio"].ToString(),
                                FundHouseId = int.Parse(dr["FundHouseId"].ToString()),
                                FundHouseName = dr["DsiplayName"].ToString()
                            } into fundHousegrp
                            select new MutualFundTransactions()
                            {
                                FundHouse = new MutualFundHouses()
                                {
                                    Id = fundHousegrp.Key.FundHouseId,
                                    Name = fundHousegrp.Key.FundHouseName
                                },
                                PortfolioDetails = new MutualFundPortfolio()
                                {
                                    Id = fundHousegrp.Key.PortfolioId,
                                    Name = fundHousegrp.Key.Portfolio
                                },
                                FundDetails = (from fund in fundHousegrp
                                               group fund by new
                                               {
                                                   FundId = int.Parse(fund["FundId"].ToString()),
                                                   SchemaCode = int.Parse(fund["SchemaCode"].ToString()),
                                                   FundName = fund["FundName"].ToString()
                                               } into fundsGrp
                                               select new MutualFundDetails()
                                               {
                                                   Id = fundsGrp.Key.FundId,
                                                   SchemaCode = fundsGrp.Key.SchemaCode,
                                                   Name =  fundsGrp.Key.FundName,

                                                   CurrentInvestments = GetMFFundInvestments(fundsGrp, "I"),
                                                   RedeemTransactions = GetMFFundInvestments(fundsGrp, "R"),
                                                   RedeemPurchases = GetMFFundInvestments(fundsGrp, "S"),
                                               }).ToList()
                            }).ToList();
                }
            }
            catch(Exception ex) { }
            return null;
        }

        private List<MutualFundTransaction> GetMFFundInvestments(IGrouping<object, DataRow> fundsGrp, string type)
        {
            List<MutualFundTransaction> result = null;
            try
            {
                if(fundsGrp != null)
                {
                    result = (from t in fundsGrp.AsEnumerable()
                              where t["Type"].ToString() == type
                              select new MutualFundTransaction()
                              {
                                  TransactionId = int.Parse(t["TransactionId"].ToString()),
                                  PurchaseDate = DateTime.Parse(t["PurchaseDate"].ToString()),
                                  Amount = decimal.Parse(t["Amount"].ToString()),
                                  CurrentValue = decimal.Parse(t["CurrentValue"].ToString()),
                                  Profit = (Convert.ToDecimal(t["CurrentValue"].ToString()) - Convert.ToDecimal(t["Amount"].ToString())),
                                  ProfitPer = GetProfitPer(t),
                                  AgePer = CalculatePercentAgeGrowth(t),
                                  Units = decimal.Parse(t["Units"].ToString()),
                                  DividendPerNAV = decimal.Parse(t["DividendPerNAV"].ToString()),
                                  Dividend = decimal.Parse(t["Dividend"].ToString()),
                                  SellDate = DateTime.Parse(t["SellDate"].ToString()),
                                  ISSIP = t["IsSipInvestment"].ToString() == "N"? false : true,

                                  FolioDetails = new MutualFundFolios()
                                  {
                                      Id = int.Parse(t["FolioId"].ToString()),
                                      Number = t["FolioNumber"].ToString()
                                  }
                              }).ToList();
                              
                }
            }
            catch(Exception ex) { }
            return result;
        }

        private decimal GetProfitPer(DataRow dr)
        {
            decimal result = 0;
            try
            {
                if (dr["Type"].ToString() == "I" || dr["Type"].ToString() == "R")
                {
                    result = (Convert.ToDecimal(dr["CurrentValue"].ToString()) - Convert.ToDecimal(dr["Amount"].ToString())) / Convert.ToDecimal(dr["Amount"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            return Math.Round(result * 100, 2, MidpointRounding.AwayFromZero);
        }

        private decimal CalculatePercentAgeGrowth(DataRow dr)
        {
            decimal result = 0;
            try
            {
                DateTime PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                DateTime SellDate = dr["Type"].ToString() == "I" ? DateTime.Now.Date : Convert.ToDateTime(dr["SellDate"].ToString());
                if (dr["Type"].ToString() == "I" || dr["Type"].ToString() == "R")
                {
                    double Amount = Convert.ToDouble(dr["Amount"].ToString());
                    double daysAge = 365 / (SellDate - PurchaseDate.Date).TotalDays;
                    double profit = Amount != 0 ? Convert.ToDouble(dr["CurrentValue"].ToString()) / Amount : 0;
                    result = (decimal)Math.Round((Math.Pow(profit, daysAge) - 1) * 100, 2, MidpointRounding.AwayFromZero);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public List<Investments> GetIndividualInvestments(DashboardIndividual request)
        {
            return MapIndividualInvestments(request, _mutualFundsDataAccess.GetInvestments(request));
        }

        private List<Investments> MapIndividualInvestments(DashboardIndividual request, DataTable dataTable)
        {
            List<Investments> result = null;
            try
            {
                if (dataTable != null)
                {
                    result = (from dr in dataTable.AsEnumerable()
                                  //where (dr["Type"].ToString() == "I")
                              select new Investments()
                              {
                                  Date = (dr["Type"].ToString() == "R") ? Convert.ToDateTime(dr["SellDate"].ToString()) : Convert.ToDateTime(dr["PurchaseDate"].ToString()),
                                  FundName = dr["FundName"].ToString(),
                                  Investment = decimal.Round(Convert.ToDecimal(dr["Amount"].ToString()), 2, MidpointRounding.AwayFromZero),
                                  CurrentValue = decimal.Round(Convert.ToDecimal(dr["CurrentValue"].ToString()), 2, MidpointRounding.AwayFromZero),
                                  Profit = GetProfitPer(dr),
                                  //RedeemInvest = decimal.Round(Convert.ToDecimal(dr["RedeemAmount"].ToString()), 2, MidpointRounding.AwayFromZero),

                                  AgePer = CalculatePercentAgeGrowth(dr),
                                  Type = dr["Type"].ToString()
                              }).ToList();

                    //var redeemTrans = (from dr in dataTable.AsEnumerable()
                    //                   where (dr["Type"].ToString() == "R")
                    //                   select new Investments()
                    //                   {
                    //                       Date = Convert.ToDateTime(dr["SellDate"].ToString()),
                    //                       FundName = dr["FundName"].ToString(),
                    //                       Investment = decimal.Round(Convert.ToDecimal(dr["RedeemAmount"].ToString()), 2, MidpointRounding.AwayFromZero),
                    //                       CurrentValue = decimal.Round(Convert.ToDecimal(dr["RedeemValue"].ToString()), 2, MidpointRounding.AwayFromZero),
                    //                       Profit = GetProfitPer(dr),
                    //                       RedeemInvest = decimal.Round(Convert.ToDecimal(dr["RedeemValue"].ToString()), 2, MidpointRounding.AwayFromZero),
                    //                       AgePer = CalculatePercentAgeGrowth(dr),
                    //                       Type = "R"
                    //                   });

                    //if (redeemTrans != null && redeemTrans.Count() > 0)
                    //    result = result.Union(redeemTrans).ToList();

                    //var sellTrans = (from dr in dataTable.AsEnumerable()
                    //                 where (dr["Type"].ToString() == "S")
                    //                 select new Investments()
                    //                 {
                    //                     Date = Convert.ToDateTime(dr["PurchaseDate"].ToString()),
                    //                     FundName = dr["FundName"].ToString(),
                    //                     Investment = decimal.Round(Convert.ToDecimal(dr["Amount"].ToString()), 2, MidpointRounding.AwayFromZero),
                    //                     Type = "S"
                    //                 });
                    //if (redeemTrans != null && redeemTrans.Count() > 0)
                    //    result = result.Union(sellTrans).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return result.OrderByDescending(r => r.Date).ToList();
        }
    }

}
