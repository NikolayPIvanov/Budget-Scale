using System.Collections.Generic;

namespace BudgetScale.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            this.Categories = new HashSet<Category>();
        }
        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Category> Categories { get; private set; }


    }
}