using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SpeedLedger.BusinessLogic;
using SpeedLedger.DataAccessLayer;
using SpeedLedger.Model;
using System.Collections.Generic;

namespace SpeedLedger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IDataAccess _dataAccess;

        public BankAccountsController(IHostingEnvironment hostingEnvironment, IDataAccess dataAccess)
        {
            _hostingEnvironment = hostingEnvironment;

            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Returns all bank accounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllBankAccounts()
        {
            var accounts = GetBankAccountsData();

            return Ok(accounts);
        }

        /// <summary>
        /// Returns the default bank account according to BusinessLogic/AccountCalculation/RetrieveDefaultAccount
        /// </summary>
        /// <returns></returns>
        [Route("default")]
        [HttpGet]
        public ActionResult GetDefaultBankAccount()
        {
            var accountsData = GetBankAccountsData();

            var result = AccountCalculation.RetrieveDefaultAccount(accountsData);

            if (result != null)
                return Ok(result.Id);
            else
                return BadRequest(result);
        }

        private List<BankAccountsModel> GetBankAccountsData()
        {
            string filePath = _hostingEnvironment.ContentRootPath + "bankaccounts.json";

            return _dataAccess.RetrieveAccountsData();
        }
    }
}