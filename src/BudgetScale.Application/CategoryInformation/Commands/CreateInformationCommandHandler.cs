using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Application.CategoryInformation.Commands
{
    public class CreateInformationCommandHandler : BaseHandler, IRequestHandler<CreateInformationCommand, Unit>
    {
        public CreateInformationCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(CreateInformationCommand request, CancellationToken cancellationToken)
        {
            var months = new List<string> {
                DateTime.UtcNow.AddMonths(-1).ToString("MMM"),
                DateTime.UtcNow.ToString("MMM"),
                DateTime.UtcNow.AddMonths(1).ToString("MMM")
            };

            var inforamtion = new List<Domain.Entities.CategoryInformation>();

            foreach (var month in months)
            {
                inforamtion.Add(new Domain.Entities.CategoryInformation
                {
                    Category = await _context.Categories.FirstOrDefaultAsync(e => e.CategoryId.Equals(request.Category)),
                    CategoryId = request.Category,
                    Month = month
                });
            }

            _context.CategoryInformations.AddRange(inforamtion);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}