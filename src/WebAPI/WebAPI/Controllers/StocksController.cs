using BusinessAccess;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class StocksController : ApiController
    {
        //public HttpResponseMessage post(StocksRequest request)
        //{
        //    StocksBusinessAccess fs = new StocksBusinessAccess();
        //    List<StockPurchases> lsp = new List<StockPurchases>();
        //    lsp = fs.ToGetStocks(request.FromDate, request.ToDate);
        //    return Request.CreateResponse(HttpStatusCode.OK, lsp);
        //}

        [HttpPost]
        public HttpResponseMessage GetStocks(StocksRequest request)
        {
            StocksBusinessAccess fs = new StocksBusinessAccess();
            List<StockPurchases> lsp = new List<StockPurchases>();
            lsp = fs.ToGetStocks(request.FromDate, request.ToDate);
            return Request.CreateResponse(HttpStatusCode.OK, lsp);
        }
    }
}
