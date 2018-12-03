using AutoMapper;
using BudgetScale.Persistence;

namespace BudgetScale.Application
{
    public abstract class BaseHandler
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseHandler(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
    }
}