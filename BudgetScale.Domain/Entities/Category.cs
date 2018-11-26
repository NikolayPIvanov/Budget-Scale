namespace BudgetScale.Domain.Entities
{
    public class Category
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Group Group { get; set; }

        public string GroupId { get; set; }
    }
}