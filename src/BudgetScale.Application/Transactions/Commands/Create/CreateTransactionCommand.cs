using MediatR;

namespace BudgetScale.Application.Transactions.Commands.Create
{
    public class CreateTransactionCommand : IRequest<string>
    {
        public string SourceAccountId { get; set; }

        public string DestinationAccountId { get; set; }

        public string CategoryId { get; set; }

        public string Reason { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }


    }
}