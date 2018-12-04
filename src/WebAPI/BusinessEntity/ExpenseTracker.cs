using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class AccountDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpeningDate { get; set; }
        public Decimal? Limit { get; set; }
        public DateTime? LimitIncreaseDate { get; set; }
        public string LimitIncreaseStatus { get; set; }
        public AccountType AccountType { get; set; }
    }

    public class ExpenseGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExpenseSubGroup
    {
        public int Id { get; set; }
        public string SubGroupName { get; set; }
        public int GroupId { get; set; }
    }

    public class ExpenseTransaction
    {
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string Item { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public string TransactedBy { get; set; }
        public string Store { get; set; }
    }
}
