using AutoMapper;

namespace BudgetScale.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);

    }
}