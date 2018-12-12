using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Categories.Commands.DeleteCommand
{
    public class DeleteCategoryCommandHandler : BaseHandler,IRequestHandler<DeleteCategoryCommand,Unit>
    {
        public DeleteCategoryCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _context.Categories.Where(c => c.CategoryId.Equals(request.CategoryId))
                .DeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}