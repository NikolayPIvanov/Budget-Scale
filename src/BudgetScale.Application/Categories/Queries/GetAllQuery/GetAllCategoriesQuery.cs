﻿using System.Linq;
using BudgetScale.Domain.Entities;
using MediatR;

namespace BudgetScale.Application.Categories.Queries.GetAllQuery
{
    public class GetAllCategoriesQuery : IRequest<IQueryable<Category>>
    {
        public string UserId { get; set; }

        public string GroupId { get; set; }

    }
}