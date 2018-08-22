using Newtonsoft.Json;
using SpeedLedger.Model;
using System.Collections.Generic;

namespace SpeedLedger.DataAccessLayer
{
    // Todo: Make this polymorphic. Perhaps with a common interface so it will easy to switch to another data source.
    public static class FileAccess
    {
        public static List<BankAccountsModel> RetrieveAccountsData(string fileName)
        {
            var json = System.IO.File.ReadAllText(fileName);

            var bankAccounts = JsonConvert.DeserializeObject<List<BankAccountsModel>>(json);

            return bankAccounts;
        }
    }
}
