using AutoMapper;
using BudgetScale.Persistence;

namespace BudgetScale.Application
{
    public abstract class BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseEntity(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
    }
}