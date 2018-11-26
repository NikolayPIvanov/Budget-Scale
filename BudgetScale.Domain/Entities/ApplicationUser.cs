namespace BudgetScale.Domain.Entities
{
    using System;
    using BudgetScale.Domain.EntityContracts;
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser, IAuditInfo
    {
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
    }
}