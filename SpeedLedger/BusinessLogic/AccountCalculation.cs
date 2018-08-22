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

            int? indexOfHighestBalance = null;
            for (var i = 0; i < validAccounts.Count; i++)
            {
                var item = validAccounts[i];
                foreach (var j in validAccounts)
                {
                    // Don't compare to self.
                    if (item.balance * 2 > j.balance && item.Id != j.Id)
                        indexOfHighestBalance = i;
                }
            }

            if (indexOfHighestBalance != null)
                return validAccounts[indexOfHighestBalance.Value];

            return null;
        }
    }
}
