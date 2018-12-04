namespace BudgetScale.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using BudgetScale.Domain.EntityContracts;
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public ApplicationUser()
        {
            this.Groups = new HashSet<Group>();
            this.Accounts = new HashSet<Account>();
        }
        private bool _isLockedOut;

        public string FullName { get; set; }

        public bool IsLockedOut
        {
            get => _isLockedOut = this.LockoutEnabled && this.LockoutEnd < DateTime.UtcNow;
            set => this._isLockedOut = value;
        }

        // Audit info
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public ICollection<Group> Groups { get; private set; }

        public ICollection<Account> Accounts { get; private set; }
    }
}