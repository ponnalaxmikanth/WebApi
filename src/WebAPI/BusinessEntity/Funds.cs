using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.MutualFunds
{
    public class MutualFundRequest
    {
        public int PortfolioId { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }
    }

    public class MutualFundTransactions
    {
        public MutualFundPortfolio PortfolioDetails { get; set; }
        public MutualFundHouses FundHouse { get; set; }
        public List<MutualFundDetails> FundDetails { get; set; }
    }

    public class MutualFundPortfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class MutualFundHouses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class MutualFundDetails
    {
        public int Id { get; set; }
        public int SchemaCode { get; set; }
        public string Name { get; set; }
        //public int GrowthSchemaCode { get; set; }
        //public string GrowthFundName { get; set; }
        
        //public MF_FundTypes Type { get; set; }
        //public MF_FundCategory Category { get; set; }
        //public MF_FundOptions Options { get; set; }

        public List<MutualFundTransaction> CurrentInvestments { get; set; }
        public List<MutualFundTransaction> RedeemTransactions { get; set; }
        public List<MutualFundTransaction> RedeemPurchases { get; set; }
    }

    public class MutualFundTransaction
    {
        public MutualFundFolios FolioDetails { get; set; }
        public int TransactionId { get; set; }

        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal Profit { get; set; }
        public decimal ProfitPer { get; set; }
        public decimal AgePer { get; set; }
        public decimal Units { get; set; }
        public decimal DividendPerNAV { get; set; }
        public decimal Dividend { get; set; }
        public DateTime SellDate { get; set; }
        public bool ISSIP { get; set; }
        public int SipID { get; set; }
    }

    public partial class MutualFundFolios
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDefaultFolio { get; set; }
    }

    public class Investments
    {
        //public MF_Portfolio Portfolio { get; set; }
        public string FundName { get; set; }
        public DateTime Date { get; set; }
        public decimal Investment { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal Profit { get; set; }
        public decimal RedeemInvest { get; set; }
        public decimal Value { get; set; }

        public decimal CurrentProfit { get; set; }
        public decimal Dividend { get; set; }

        public decimal ProfitPer { get; set; }
        public decimal RedeemValue { get; set; }

        public decimal AgePer { get; set; }
        public string Type { get; set; }
    }
}
