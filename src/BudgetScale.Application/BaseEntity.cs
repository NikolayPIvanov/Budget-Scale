using AutoMapper;
using BudgetScale.Persistence;

namespace BudgetScale.Application
{
    public abstract class BaseHandler   
    {
        protected readonly ApplicationDbContext Context;

        protected BaseHandler(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}