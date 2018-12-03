using MediatR;

namespace BudgetScale.Application.Categories.Commands.CreateCommand
{
    public class CreateCategoryCommand : IRequest<string>
    {
        /* public Category()
        {
            this.CategoryInformation = new HashSet<CategoryInformation>();
            this.Transactions = new HashSet<Transaction>();
            this.CreatedOn = DateTime.UtcNow;
        }
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Group Group { get; set; }

        public string GroupId { get; set; }

        public ICollection<CategoryInformation> CategoryInformation { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        */
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string GroupId { get; set; }

    }
}