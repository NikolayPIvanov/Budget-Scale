using System.Linq;
using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Domain.Entities;

namespace BudgetScale.Infrastructure.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupViewModel>();

            CreateMap<CreateGroupCommand, Group>();

            
        }
    }
}