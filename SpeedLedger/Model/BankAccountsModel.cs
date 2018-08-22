namespace SpeedLedger.Model
{
    public class BankAccountsModel
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public bool creditcard { get; set; }
        public bool synthetic { get; set; }
        public decimal balance { get; set; }
    }
}
