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
        StocksBusinessAccess _StocksBusinessAccess;
        public StocksController()
        {
            _StocksBusinessAccess = new StocksBusinessAccess();
        }

        [HttpPost]
        public HttpResponseMessage GetStocks(StocksRequest request)
        {
            List<StocksEntity> lsp = _StocksBusinessAccess.ToGetStocks(request.FromDate, request.ToDate, request.Detail);
            return Request.CreateResponse(HttpStatusCode.OK, lsp);
        }

    }
}
