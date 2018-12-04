using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class ExpensesTrackerRepository
    {
        public List<AccountType> GetAccountTypes()
        {
            List<AccountType> result = null;
            try
            {
                return MapAccountTypes((new ExpensesTrackerDataAccess()).GetAccountTypes());
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        private List<AccountType> MapAccountTypes(DataTable dataTable)
        {
            List<AccountType> result = null;
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    result = (from dr in dataTable.AsEnumerable()
                              select new AccountType()
                              {
                                  Id = int.Parse(dr["AccountTypeId"].ToString()),
                                  Type = dr["AccountType"].ToString()
                              }).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }
        

        public List<AccountDetails> GetAccountDetails()
        {
            List<AccountDetails> result = null;
            try
            {
                return MapAccountDetails((new ExpensesTrackerDataAccess()).GetAccountDetails());
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private List<AccountDetails> MapAccountDetails(DataTable dataTable)
        {
            List<AccountDetails> result = null;
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    result = (from dr in dataTable.AsEnumerable()
                              select new AccountDetails()
                              {
                                  Id = int.Parse(dr["AccountId"].ToString()),
                                  Name = dr["Name"].ToString(),
                                  OpeningDate = Convert.ToDateTime(dr["OpenDate"]),
                                  AccountType = new AccountType()
                                  {
                                      Id = int.Parse(dr["AccountTypeId"].ToString()),
                                      Type = dr["AccountType"].ToString(),
                                  }

                              }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public List<ExpenseGroup> GetExpenseGroups()
        {
            try
            {
                return MapExpenseGroups((new ExpensesTrackerDataAccess()).GetExpenseGroups());
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private List<ExpenseGroup> MapExpenseGroups(DataTable dataTable)
        {
            List<ExpenseGroup> result = null;
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    result = (from dr in dataTable.AsEnumerable()
                              select new ExpenseGroup()
                              {
                                  Id = int.Parse(dr["GroupId"].ToString()),
                                  Name = dr["GroupName"].ToString(),
                              }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public List<ExpenseSubGroup> GetExpenseSubGroups()
        {
            try
            {
                return MapExpenseSubGroups((new ExpensesTrackerDataAccess()).GetExpenseSubGroups());
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        private List<ExpenseSubGroup> MapExpenseSubGroups(DataTable dataTable)
        {
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (from dr in dataTable.AsEnumerable()
                              select new ExpenseSubGroup()
                              {
                                  GroupId = int.Parse(dr["GroupId"].ToString()),
                                  Id = int.Parse(dr["Id"].ToString()),
                                  SubGroupName = dr["SubGroupName"].ToString(),
                              }).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }


        public bool AddExpenseTransaction(ExpenseTransaction transaction)
        {
            try
            {
                return GetAddExpenseStatus(new ExpensesTrackerDataAccess().AddExpenseTransaction(transaction));
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        private bool GetAddExpenseStatus(DataTable dataTable)
        {
            try
            {
                if(dataTable != null && dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0][0].ToString() == "0" ? true : false;
                }
            }
            catch(Exception ex)
            {

            }
            return false;
        }


        public List<string> GetItems(string item)
        {
            try
            {
                return MapItems((new ExpensesTrackerDataAccess()).GetItem(item));
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        private List<string> MapItems(DataTable dataTable)
        {
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (from dr in dataTable.AsEnumerable()
                            select dr["Item"].ToString()).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }


        public List<string> GetStores(string store)
        {
            try
            {
                return MapStores((new ExpensesTrackerDataAccess()).GetStores(store));
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private List<string> MapStores(DataTable dataTable)
        {
            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return (from dr in dataTable.AsEnumerable()
                            select dr["Store"].ToString()).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
