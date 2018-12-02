using System;
using AutoMapper;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.CategoryInformation.Models.Output;
using BudgetScale.Application.Groups.Models.Input.Create;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Infrastructure
{
    [TestFixture]
    public class BudgetScaleTestBase : IDisposable
    {
        protected ApplicationDbContext context;
        protected IMapper mapper;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            this.context = new ApplicationDbContext(options);

            this.context.Database.EnsureCreated();

            //Mapper.Initialize(config =>
            //{
            //    //config.CreateMap<Group, GroupViewModel>();
            //    //config.CreateMap<Category, CategoryViewModel>();
            //    //config.CreateMap<Domain.Entities.CategoryInformation, CategoryInformationViewModel>();
            //    //config.CreateMap<CommandInputModel, Group>();

            //});

            Initializer.Initialize(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            this.Dispose();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}