using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class DashboardRequest
    {
        public int PortfolioId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class DashboardIndividual : DashboardRequest
    {
        public string Type { get; set; }
    }

    public class PortFolioDetails
    {
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
    }

    public class MFTransactions
    {
        public int TransactionId { get; set; }

        public int FolioId { get; set; }
        public string FolioNumber { get; set; }

        public FundHouseDetails FundHouses { get; set; }

        public FundDetails FundDetails { get; set; }

        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Units { get; set; }
        public decimal DividendPerNAV { get; set; }
        public decimal Dividend { get; set; }

        public decimal CurrentValue { get; set; }
        public DateTime SellDate { get; set; }

        public string Type { get; set; }
    }

    public class FundHouseDetails
    {
        public int FundHouseId { get; set; }
        public string FundHouse { get; set; }
    }

    public class FundDetails
    {
        public int FundClassId { get; set; }
        public string FundClass { get; set; }

        public int FundId { get; set; }
        public string FundName { get; set; }

        public bool IsSectorFund { get; set; }
    }

    public partial class MF_Folios
    {
        public int FolioId { get; set; }
        public int FundHouseId { get; set; }
        public string FolioNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PortfolioId { get; set; }
        public bool isDefaultFolio { get; set; }
    }

    public partial class MF_FundCategory
    {
        public int FundClassId { get; set; }
        public string FundClass { get; set; }
        public Nullable<bool> IsSectorCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public partial class MF_FundHouses
    {
        public int FundHouseId { get; set; }
        public string FundHouseName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public partial class MF_FundOptions
    {
        public int OptionId { get; set; }
        public string FundOption { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public partial class MF_FundTypes
    {
        public int FundTypeId { get; set; }
        public string FundType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public partial class MF_Portfolio
    {
        public int PortfolioId { get; set; }
        public string Portfolio { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class MFFund
    {
        public int FundId { get; set; }
        public MF_FundHouses FundHouse { get; set; }
        public MF_FundTypes FundType { get; set; }
        public MF_FundCategory FundCategory { get; set; }
        public MF_FundOptions FundOptions { get; set; }

        public int SchemaCode { get; set; }
        public int GrowthSchemaCode { get; set; }
        public string GrowthFundName { get; set; }
        public string FundName { get; set; }
    }

    public class Funds
    {
        public int FundHouseId { get; set; }
        public int SchemaCode { get; set; }
        public string Name { get; set; }
        public string GrowthISIN { get; set; }
        public string DividendReInvestISIN { get; set; }
    }

    public partial class AddMFTransactionRequest
    {
        public int PortfolioId { get; set; }
        public int FundHouseId { get; set; }
        public int FundTypeId { get; set; }
        public int FundCategoryId { get; set; }
        public int FundOptionsId { get; set; }
        public int FundId { get; set; }
        public string FundName { get; set; }
        public int SchemaCode { get; set; }
        public int GrowthFundId { get; set; }
        public int GrowthSchemaCode { get; set; }
        public int FolioId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public decimal PurchaseNAV { get; set; }
        public decimal Units { get; set; }

        public bool IsSIP { get; set; }
    }

    public partial class GetFundNavRequest
    {
        public int SchemaCode { get; set; }
        public DateTime Date { get; set; }
    }

    public partial class GetFundValueRequst
    {
        public int PortfolioId { get; set; }
        public int SchemaCode { get; set; }
        public int FolioId { get; set; }
        public int OptionId { get; set; }
    }

    public partial class FundValueResponse
    {
        public int SchemaCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Units { get; set; }
        public decimal Dividend { get; set; }
        public decimal AvgNav { get; set; }
        public decimal LatestNav { get; set; }
        public DateTime Date { get; set; }
        public decimal LatestValue { get; set; }
    }

    public class GetMyFundsRequest
    {
        public string Type { get; set; }
        public int PortfolioId { get; set; }
    }

}
