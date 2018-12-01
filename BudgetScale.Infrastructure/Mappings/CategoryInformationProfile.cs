using AutoMapper;
using BudgetScale.Application.CategoryInformation.Models.Output;
using BudgetScale.Domain.Entities;

namespace BudgetScale.Infrastructure.Mappings
{
    public class CategoryInformationProfile : Profile
    {
        public CategoryInformationProfile()
        {
            CreateMap<CategoryInformation, CategoryInformationViewModel>();

        }
    }
}