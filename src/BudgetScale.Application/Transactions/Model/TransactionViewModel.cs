namespace BudgetScale.Application.Transactions.Model
{
    public class TransactionViewModel
    {

        public string Reason { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }
        
        public string CategoryName { get; set; }

        public string SourceAccountName { get; set; }

        public string DestinationAccountName { get; set; }

        public string Type { get; set; }
    }
}