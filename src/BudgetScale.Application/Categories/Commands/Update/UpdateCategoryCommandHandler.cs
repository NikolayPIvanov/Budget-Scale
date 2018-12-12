using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommand,Unit>
    {
        public UpdateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            await _context.Categories.Where(e => e.CategoryId.Equals(request.CategoryId)).UpdateAsync(x =>
                new Category()
                {
                    CategoryName = request.CategoryName
                });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}