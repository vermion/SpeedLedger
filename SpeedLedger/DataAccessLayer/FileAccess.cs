using Newtonsoft.Json;
using SpeedLedger.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SpeedLedger.DataAccessLayer
{
    // Todo: Make this polymorphic. Perhaps with a common interface so it will easy to switch to another data source.
    public class FileAccess : IDataAccess
    {

        private string filePath { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileAccess(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            filePath = _hostingEnvironment.ContentRootPath + @"/bankaccounts.json";
        }
        
        public List<BankAccountsModel> RetrieveAccountsData()
        {
            var json = System.IO.File.ReadAllText(filePath);

            var bankAccounts = JsonConvert.DeserializeObject<List<BankAccountsModel>>(json);

            return bankAccounts;
        }
    }
}
