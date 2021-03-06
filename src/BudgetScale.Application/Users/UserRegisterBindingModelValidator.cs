﻿using FluentValidation;

namespace BudgetScale.Application.Users
{
    public class UserRegisterBindingModelValidator : AbstractValidator<UserRegisterBindingModel>
    {
        public UserRegisterBindingModelValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.Password).Length(6, 32);
            RuleFor(e => e.FullName).Length(6, 50).NotEmpty();
        }
    }
}