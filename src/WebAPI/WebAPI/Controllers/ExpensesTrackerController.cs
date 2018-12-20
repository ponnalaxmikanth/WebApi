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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpensesTrackerController : ApiController
    {

        [HttpGet]
        [Route("api/Expenses/GetAccountTypes")]
        public HttpResponseMessage GetAccountTypes()
        {
            List<AccountType> result = new ExpensesTrackerRepository().GetAccountTypes();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Expenses/GetAccountDetails")]
        public HttpResponseMessage GetAccountDetails()
        {
            List<AccountDetails> result = new ExpensesTrackerRepository().GetAccountDetails();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Expenses/GetExpenseGroups")]
        public HttpResponseMessage GetExpenseGroups()
        {
            List<ExpenseGroup> result = new ExpensesTrackerRepository().GetExpenseGroups();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Expenses/GetExpenseSubGroups")]
        public HttpResponseMessage GetExpenseSubGroups()
        {
            List<ExpenseSubGroup> result = new ExpensesTrackerRepository().GetExpenseSubGroups();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Expenses/GetItems/{item}")]
        public HttpResponseMessage GetItems(string item)
        {
            List<string> result = new ExpensesTrackerRepository().GetItems(item);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/Expenses/GetStores/{store}")]
        public HttpResponseMessage GetStores(string store)
        {
            List<string> result = new ExpensesTrackerRepository().GetStores(store);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/Expenses/AddExpense")]
        public HttpResponseMessage AddTransaction(ExpenseTransaction transaction)
        {
            Boolean result = new ExpensesTrackerRepository().AddExpenseTransaction(transaction);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/Expenses/GetExpenses")]
        public HttpResponseMessage GetTransaction(GetExpenses request)
        {
            List<Expenses> result = new ExpensesTrackerRepository().GetExpenses(request);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
