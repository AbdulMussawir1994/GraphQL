﻿using FluentValidation;
using GraphQL.Models;

namespace GraphQL.Helpers;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.FullName).NotEmpty().MaximumLength(100);
        RuleFor(e => e.Email).NotEmpty().EmailAddress();
        RuleFor(e => e.Department).NotEmpty();
    }
}

public class CreateEmployeeInputValidator : AbstractValidator<CreateEmployeeInput>
{
    public CreateEmployeeInputValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Department).NotEmpty();
    }
}