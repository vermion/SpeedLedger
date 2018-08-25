using SpeedLedger.Model;
using System.Collections.Generic;
using System.Linq;

namespace SpeedLedger.BusinessLogic
{
    public static class AccountCalculation
    {
        public static BankAccountsModel RetrieveDefaultAccount(List<BankAccountsModel> bankAccounts)
        {

            if (bankAccounts == null)
                return null;

            if (!bankAccounts.Any())
                return null;

            var validAccounts = bankAccounts.Where(s => s.synthetic == false)
                .Where(b => b.balance > 0)
                .ToList();

            if (!validAccounts.Any())
                return null;

            if (validAccounts.Count == 1)
                return validAccounts.First();

            var highestAccount = validAccounts.OrderByDescending(b => b.balance).First();

            bool? accountWithTwoTimesBalance = null;
            for (var i = 0; i < validAccounts.Count; i++)
            {
                if (validAccounts[i].Id != highestAccount.Id)
                {
                    if (2 * validAccounts[i].balance <= highestAccount.balance)
                        accountWithTwoTimesBalance = true;
                    else
                    {
                        accountWithTwoTimesBalance = false;
                        break;
                    }
                } 
            }

            if (accountWithTwoTimesBalance == true)
                return highestAccount;

            return null;
        }
    }
}
