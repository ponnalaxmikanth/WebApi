using BusinessAccess;
using BusinessEntity;
using BusinessEntity.MutualFunds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MutualFundsController : ApiController
    {
        [HttpGet]
        [Route("api/MutualFunds/GetFundHouses")]
        public HttpResponseMessage GetFundHouses()
        {
            List<MF_FundHouses> result = new MutualFundsRepository().GetFundHouses();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/MutualFunds/GetFundTypes")]
        public HttpResponseMessage GetFundTypes()
        {
            List<MF_FundTypes> result = new MutualFundsRepository().GetFundTypes();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/MutualFunds/GetFundCategory")]
        public HttpResponseMessage GetFundCategory()
        {
            List<MF_FundCategory> result = new MutualFundsRepository().GetFundCategory();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpGet]
        [Route("api/MutualFunds/GetFundOptions")]
        public HttpResponseMessage GetFundOptions()
        {
            List<MF_FundOptions> result = new MutualFundsRepository().GetFundOptions();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpGet]
        [Route("api/MutualFunds/GetFunds")]
        public HttpResponseMessage GetFunds()
        {
            List<Funds> result = new MutualFundsRepository().GetFunds();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/MutualFunds/GetFolios")]
        public HttpResponseMessage GetFolios()
        {
            List<MF_Folios> result = new MutualFundsRepository().GetFolios();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/MutualFunds/GetPortfolios")]
        public HttpResponseMessage GetPortfolios()
        {
            List<PortFolioDetails> result = new MutualFundsRepository().GetPortfolios();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetMyFunds")]
        public HttpResponseMessage GetMyFunds(GetMyFundsRequest request)
        {
            List<MFFund> result = new MutualFundsRepository().GetMyFunds(request);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/MutualFunds/AddTransaction")]
        public HttpResponseMessage AddTransaction(AddMFTransactionRequest _mfTransactionRequest)
        {
            AddMFTransactionResponse response = new MutualFundsRepository().AddTransaction(_mfTransactionRequest);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetFundNav")]
        public HttpResponseMessage GetFundNav(GetFundNavRequest _getFundNavRequest)
        {
            decimal value = new MutualFundsRepository().GetFundNav(_getFundNavRequest);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetFundValue")]
        public HttpResponseMessage GetFundValue(GetFundValueRequst _getFundValueRequest)
        {
            FundValueResponse response = new MutualFundsRepository().GetFundValue(_getFundValueRequest);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetMFFundInvestments")]
        public HttpResponseMessage GetMFFundInvestments(GetMFFundInvestmentsRequest _getMFFundInvestmentsRequest)
        {
            List<MFTransactions> response = new MutualFundsRepository().GetMFFundInvestments(_getMFFundInvestmentsRequest);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetMFDdailyTracker")]
        public HttpResponseMessage GetMFDdailyTracker(GetMFDailyTracker _request)
        {
            List<DailyMFTracker> response = new MutualFundsRepository().GetMFDdailyTracker(_request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/MutualFunds/GetFundTransactions")]
        public HttpResponseMessage GetFundTransactions(MutualFundRequest _getFundTransactions)
        {
            List<MutualFundTransactions> response = new MutualFundsRepository().GetFundTransactions(_getFundTransactions);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
