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

        public BankAccountsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Returns all bank accounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllBankAccounts()
        {
            string content = _hostingEnvironment.ContentRootPath + "/bankaccounts.json";
            var accountsData = FileAccess.RetrieveAccountsData(content);

            return Ok(accountsData);
        }

        /// <summary>
        /// Returns a valid bank account according to requirement: XXXX-1234.
        /// </summary>
        /// <returns></returns>
        [Route("default")]
        [HttpGet]
        public ActionResult GetDefaultBankAccount()
        {
            var accountsData = GetBankAccountsData();

            var result = AccountCalculation.RetrieveDefaultAccount(accountsData);

            return Ok(result.Id);
        }

        private List<BankAccountsModel> GetBankAccountsData()
        {
            string filePath = _hostingEnvironment.ContentRootPath + "/bankaccounts.json";

            return FileAccess.RetrieveAccountsData(filePath);
        }
    }
}