using SpeedLedger.Model;
using System.Collections.Generic;

namespace SpeedLedger.DataAccessLayer
{
    public interface IDataAccess
    {
        List<BankAccountsModel> RetrieveAccountsData();
    }
}