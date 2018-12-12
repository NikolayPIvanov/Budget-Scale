using MediatR;

namespace BudgetScale.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}