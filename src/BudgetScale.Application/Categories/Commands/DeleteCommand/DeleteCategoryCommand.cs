using MediatR;

namespace BudgetScale.Application.Categories.Commands.DeleteCommand
{
    public class DeleteCategoryCommand  : IRequest<Unit>
    {
        public string CategoryId { get; set; }
    }
}