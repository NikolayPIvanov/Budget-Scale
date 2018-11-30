using BudgetScale.Persistence;

namespace BudgetScale.Application
{
    public abstract class BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        protected BaseEntity(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}