namespace BudgetScale.Application.Groups.Models.Output
{
    public class GroupDashboardViewModel : GroupViewModel
    {
        public decimal Budgeted { get; set; }

        public decimal Activity { get; set; }

        public decimal Availability { get; set; }
    }   
}