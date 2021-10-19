using FluentValidation;
using ModelValidation.Models;

namespace ModelValidation.ModelValidators
{
    public class PersonValidator<T> : AbstractValidator<T> where T : Person
    {
        public PersonValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} cannot be null").WithErrorCode(ErrorCode.ERR1.ToString())
                .Must(ValidationHelpers.IsValidName).WithMessage("{PropertyName} is Invalid").WithErrorCode(ErrorCode.ERR2.ToString())
                .Length(1, 50).WithMessage("Length({TotalLength}) of {PropertyName} exceeds allowed Length 50.").WithErrorCode(ErrorCode.ERR3.ToString());
            RuleFor(p => p.Lastname)
                .NotEmpty().WithMessage("{PropertyName} cannot be null").WithErrorCode(ErrorCode.ERR2.ToString())
                .Must(ValidationHelpers.IsValidName).WithMessage("{PropertyName} is Invalid").WithErrorCode(ErrorCode.ERR2.ToString())
                .Length(1, 50).WithMessage("Length({TotalLength}) of {PropertyName} exceeds allowed Length 50.").WithErrorCode(ErrorCode.ERR3.ToString());
        }
    }
}

