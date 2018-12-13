using System;
using AutoMapper;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Z.EntityFramework.Plus;

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

            BatchUpdateManager.InMemoryDbContextFactory = () => new ApplicationDbContext(options);
            BatchDeleteManager.InMemoryDbContextFactory = () => new ApplicationDbContext(options);

            this.context.Database.EnsureCreated();
            this.mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateGroupCommand, Group>();
            }));

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