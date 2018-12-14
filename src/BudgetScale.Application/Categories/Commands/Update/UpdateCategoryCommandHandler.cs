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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,Unit>
    {
        public ApplicationDbContext Context { get; }

        public UpdateCategoryCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            await Context.Categories.Where(e => e.CategoryId.Equals(request.CategoryId)).UpdateAsync(x =>
                new Category()
                {
                    CategoryName = request.CategoryName
                }, cancellationToken: cancellationToken);

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}