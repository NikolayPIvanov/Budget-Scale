using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Transactions.Commands.Create
{
    public class CreateTransactionCommandHandler : BaseHandler, IRequestHandler<CreateTransactionCommand,string>
    {
        public async Task<string> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Amount = request.Amount,
                DestinationAccount = await Context.Accounts
                    .FirstOrDefaultAsync(e => e.AccountId.Equals(request.DestinationAccountId),
                        cancellationToken: cancellationToken),
                DestinationAccountId = request.DestinationAccountId,
                Memo = request.Memo,
                Reason = request.Reason,
                SourceAccount = await Context.Accounts
                    .FirstOrDefaultAsync(e => e.AccountId.Equals(request.SourceAccountId),
                        cancellationToken: cancellationToken),
                SourceAccountId = request.SourceAccountId,
                CategoryId = request.CategoryId,
                Category = await Context.Categories.FirstOrDefaultAsync(e => e.CategoryId.Equals(request.CategoryId),
                    cancellationToken)
            };

            Context.Transactions.Add(transaction);

            await Context.SaveChangesAsync(cancellationToken);

            return transaction.TransactionId;
        }

        public CreateTransactionCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}