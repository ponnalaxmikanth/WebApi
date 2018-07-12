using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class StocksRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class StockPurchases
    {
        public string StocksId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int NumbersofStocks { get; set; }
        public decimal StocksPrice { get; set; }

    }

}
