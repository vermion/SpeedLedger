using System;
using System.Collections.Generic;
using Xunit;
using SpeedLedger.Model;

namespace UnitTests
{
    public class Class1
    {
        /// <summary>
        /// If two valid accounts have the same balance result should be null.
        /// </summary>
        [Fact]
        public void TwoValidAccountsWithSameBalance()
        {
            var accounts = GetTestAccounts(@"\TwoValidAccountsWithSameBalance.json");
            var result = SpeedLedger.BusinessLogic.AccountCalculation.RetrieveDefaultAccount(accounts);
            Assert.Null(result);
        }

        /// <summary>
        /// If no valid accounts result should be null.
        /// </summary>
        [Fact]
        public void NoValidAccounts()
        {
            var accounts = GetTestAccounts(@"\NoValidAccounts.json");
            var result = SpeedLedger.BusinessLogic.AccountCalculation.RetrieveDefaultAccount(accounts);
            Assert.Null(result);
        }

        /// <summary>
        /// One account has a balance with at least twice as high balance as all the other accounts.
        /// </summary>
        [Fact]
        public void OneAccountWithAtLeastTwoTimesHighestBalance()
        {
            var accounts = GetTestAccounts(@"\OneAccountWithAtLeastTwoTimesHighestBalance.json");
            var result = SpeedLedger.BusinessLogic.AccountCalculation.RetrieveDefaultAccount(accounts);
            if (result != null)
                Assert.Equal(2, result.Id);
        }

        /// <summary>
        /// Dataset only contains one account and that account is valid.
        /// </summary>
        [Fact]
        public void OneValidAccount()
        {
            var accounts = GetTestAccounts(@"\OneValidAccount.json");
            var result = SpeedLedger.BusinessLogic.AccountCalculation.RetrieveDefaultAccount(accounts);
            if (result != null)
                Assert.Equal(1, result.Id);
        }

        private List<BankAccountsModel>  GetTestAccounts(string file)
        {
            var path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            string filePath = path + file;
            return SpeedLedger.DataAccessLayer.FileAccess.RetrieveAccountsData(filePath);
        }
    }
}
