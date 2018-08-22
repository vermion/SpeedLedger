using System;
using Xunit;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
        public void TwoValidAccountsWithSameBalance()
        {
            var path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            string filePath = path + @"\BankAccountSameBalance.json";
            var result = SpeedLedger.DataAccessLayer.FileAccess.RetrieveAccountsData(filePath);
            Assert.Single(result);
        }
    }
}
