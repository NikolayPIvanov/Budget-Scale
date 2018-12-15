using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;

namespace BudgetScale.Application.Categories.Commands.CreateCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = Mapper.Map<Category>(request);

            category.Group = await Context.Groups.FindAsync(request.GroupId);

            Context.Categories.Add(category);

            await Context.SaveChangesAsync(cancellationToken);

            return category.CategoryId;

        }

        public CreateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}