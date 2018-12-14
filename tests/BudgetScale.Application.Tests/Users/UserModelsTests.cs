using BudgetScale.Application.Tests.Infrastructure;
using BudgetScale.Application.Users;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Users
{
    
    public class UserModelsTests : BudgetScaleTestBase
    {
        [Test]
        public void CredentialsModelValidator_ValidatesValidData()
        {
            var validator = new CredentialsBindingModelValidator();

            var result = validator.Validate(new CredentialsBindingModel
            {
                Email = "this.is.Arandomm3il@gmail.com",
                Password = "thisShouldB3AGoodPassword"
            });

            Assert.True(result.IsValid);
        }

        [Test]
        public void CredentialsModelValidator_CatchesInvalidEmail()
        {
            var validator = new CredentialsBindingModelValidator();

            var result = validator.Validate(new CredentialsBindingModel
            {
                Email = "invalidMail",
                Password = "thisShouldB3AGoodPassword"
            });

            Assert.True(!result.IsValid);
        }

        [Test]
        [TestCase("short")]
        [TestCase("This is actually very long password that should not be fit in the model and should be discarded")]
        public void CredentialsModelValidator_CatchesInvalidPassword(string password)
        {
            var validator = new CredentialsBindingModelValidator();

            var result = validator.Validate(new CredentialsBindingModel
            {
                Email = "this.is.Arandomm3il@gmail.com",
                Password = password
            });

            Assert.True(!result.IsValid);
        }

        [Test]
        public void UserRegisterBindingModelValidator_ValidatesValidData()
        {
            var validator = new UserRegisterBindingModelValidator();

            var result = validator.Validate(new UserRegisterBindingModel
            {
                Email = "this.is.Arandomm3il@gmail.com",
                Password = "thisShouldB3AGoodPassword",
                FullName = "A random name"
            });

            Assert.True(result.IsValid);
        }

        [Test]
        public void UserRegisterBindingModelValidator_CatchesInvalidEmail()
        {
            var validator = new UserRegisterBindingModelValidator();

            var result = validator.Validate(new UserRegisterBindingModel
            {
                Email = "invalidMail",
                Password = "thisShouldB3AGoodPassword",
                FullName = "A random name"
            });

            Assert.True(!result.IsValid);
        }

        [Test]
        [TestCase("short")]
        [TestCase("This is actually very long password that should not be fit in the model and should be discarded")]
        public void UserRegisterBindingModelValidator_CatchesInvalidPassword(string password)
        {
            var validator = new UserRegisterBindingModelValidator();

            var result = validator.Validate(new UserRegisterBindingModel
            {
                Email = "this.is.Arandomm3il@gmail.com",
                Password = password,
                FullName = "A random name"
            }); 

            Assert.True(!result.IsValid);
        }

        [Test]
        public void UserRegisterBindingModelValidator_CatchesInvalidFullName()
        {
            var validator = new UserRegisterBindingModelValidator();

            var result = validator.Validate(new UserRegisterBindingModel
            {
                Email = "invalidMail",
                Password = "thisShouldB3AGoodPassword",
                FullName = "A random name A random name A random name A random name A random name A random name A random name A random name A random name A random name A random name A random name A random name "
            });

            Assert.True(!result.IsValid);
        }


    }
}