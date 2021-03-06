﻿using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Requests.Queries.AllRequests
{
    public class AllRequests : IRequest<IQueryable<LongRequest>>
    {
        public int Hours { get; set; }
    }
}