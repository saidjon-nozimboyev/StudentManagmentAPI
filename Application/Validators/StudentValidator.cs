using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
            .WithMessage("Email should not be empty")
            .Length(5, 70)
            .WithMessage("Email should be between 5 and 70 characters");

        RuleFor(x => x.FullName).NotEmpty()
            .WithMessage("FullName can not be empty")
            .Length(3, 50)
            .WithMessage("FullName should be between 3 and 50 characters");

        RuleFor(x => x.Email).NotEmpty()
        .WithMessage("Email should not be empty")
        .Length(5, 70)
        .WithMessage("Email should be between 5 and 70 characters")
        .EmailAddress()
        .WithMessage("Email should be in a valid format");
    }
}
