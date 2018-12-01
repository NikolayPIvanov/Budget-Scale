namespace BudgetScale.Application.CategoryInformation.Models.Output
{
    public class CategoryInformationViewModel
    {
        public string CategoryInformationId { get; set; }

        /// <summary>
        /// Possibility that we do not need to return the month, only use it for requests.
        /// </summary>
        public string Month { get;  set; }

        public decimal Budgeted { get; set; }

        public decimal Activity { get; set; }

        public decimal Available { get; set; }



    }
}