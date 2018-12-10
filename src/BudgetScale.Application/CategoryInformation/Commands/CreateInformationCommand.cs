using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.CategoryInformation.Commands
{
    public class CreateInformationCommand : IRequest<Unit>
    {
        public string Category { get; set; }
    }
}