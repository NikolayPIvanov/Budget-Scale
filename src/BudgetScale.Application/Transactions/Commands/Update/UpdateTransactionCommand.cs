using MediatR;

namespace BudgetScale.Application.Transactions.Commands.Update
{
    public class UpdateTransactionCommand : IRequest<Unit>
    {
        public string TransactionId { get; set; }


        
    }
}