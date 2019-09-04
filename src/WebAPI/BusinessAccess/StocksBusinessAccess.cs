using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utilities;

namespace BusinessAccess
{
    public class StocksBusinessAccess
    {
        StocksDataAccess _StocksDataAccess;
        public StocksBusinessAccess()
        {
            _StocksDataAccess = new StocksDataAccess();
        }

        public List<StocksEntity> ToGetStocks(DateTime fromdate, DateTime todate, int Detail)
        {
            return MapsStocks(_StocksDataAccess.GetToStocks(fromdate, todate, Detail));
        }

        private List<StocksEntity> MapsStocks(DataTable da)
        {
            return (from DataRow dr in da.Rows
                   select new StocksEntity()
                   {
                       Symbol = dr["StockID"].ToString(),
                       Date = DateTime.Parse(dr["PurchaseDate"].ToString()),
                       volume = Conversions.ToDouble(dr["Quantity"].ToString(), 0),
                       close = Conversions.ToDouble(dr["Price"].ToString(), 0),
                       dividendamount = Conversions.ToDouble(dr["Dividend"].ToString(), 0),
                   }).ToList();

        }

    }
}
