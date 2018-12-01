﻿using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Domain.Entities;

namespace BudgetScale.Infrastructure.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();

        }

    }
}