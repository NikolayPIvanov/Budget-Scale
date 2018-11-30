using System;
using System.Collections.Generic;
using BudgetScale.Domain.EntityContracts;

namespace BudgetScale.Domain.Entities
{
    public class Group : IAuditInfo
    {
        public Group()
        {
            this.Categories = new HashSet<Category>();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Category> Categories { get; private set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}