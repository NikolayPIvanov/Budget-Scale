using System;
using System.Globalization;
using BudgetScale.Domain.EntityContracts;

namespace BudgetScale.Domain.Entities
{
    public class CategoryInformation : IAuditInfo
    {
        public CategoryInformation()
        {
            this.CreatedOn = DateTime.UtcNow;
            //this.Month = this.CreatedOn.ToString("MMM", CultureInfo.InvariantCulture);
        }

        public string CategoryInformationId { get; set; }

        public string Month { get; set; }

        public decimal Budgeted { get; set; }

        public decimal Activity { get; set; }

        public decimal Available { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}