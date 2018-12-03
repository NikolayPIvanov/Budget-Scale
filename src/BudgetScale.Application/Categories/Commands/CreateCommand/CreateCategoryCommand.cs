using MediatR;

namespace BudgetScale.Application.Categories.Commands.CreateCommand
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string UserId { get; set; }
        public string CategoryName { get; set; }
        public string GroupId { get; set; }

    }
}