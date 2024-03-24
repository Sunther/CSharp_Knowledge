using DomainEvents_MediatR.Domain.Entities;
using FluentValidation;

namespace DomainEvents_MediatR.Application.Validators;

internal class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(10).MinimumLength(3);
        RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50).MinimumLength(10);
    }
}
