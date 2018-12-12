using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommand,Unit>
    {
        public UpdateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Categories.FirstOrDefaultAsync(e => e.CategoryId.Equals(request.CategoryId),
                    cancellationToken);

            entity.CategoryName = request.CategoryName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}