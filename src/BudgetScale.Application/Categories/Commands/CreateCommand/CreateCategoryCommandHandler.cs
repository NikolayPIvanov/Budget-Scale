using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Z.EntityFramework.Plus;

namespace BudgetScale.Application.Categories.Commands.CreateCommand
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommand, string>
    {
        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            category.Group = await _context.Groups.FindAsync(request.GroupId);

            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);

            return category.CategoryId;

        }

        public CreateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}