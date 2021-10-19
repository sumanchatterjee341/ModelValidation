using FluentValidation;
using ModelValidation.Models;

namespace ModelValidation.ModelValidators
{
    public class StudentValidator : PersonValidator<Student>
    {
        public StudentValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(p => p.RollNumber)
                .NotNull().WithMessage("{PropertyName} cannot be null").WithErrorCode(ErrorCode.ERR1.ToString());
            RuleFor(p => p.SchoolName)
                .NotEmpty().WithMessage("{PropertyName} cannot be null").WithErrorCode(ErrorCode.ERR1.ToString());
        }
    }
}

